using BulkuBook.DataAccess.IRepository;
using BulkyBook.Model.Models;
using BulkyBook.Model.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfwork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfwork = unitOfwork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVm = new ProductVM()
            {
                product = new Product(),
                CatagoryList = _unitOfwork.catagory.GetAll().Select(i => new SelectListItem {

                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _unitOfwork.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (id == null)
            {
                return View(productVm);
            }
            productVm.product = _unitOfwork.product.Get(id.GetValueOrDefault());
            if (productVm.product == null)
            {
                return NotFound();
            }
            return View(productVm);

        }





        #region APi Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = _unitOfwork.product.GetAll(includeProperty: "Catagory,CoverType");
            return Json(new { data = obj });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productvm)
        {
            if (ModelState.IsValid)
            {
                string webRootpath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var upload = Path.Combine(webRootpath, @"images\products");
                    var extension = Path.GetExtension(files[0].FileName);
                    if (productvm.product.ImageUrl != null)
                    {
                        //this is edit so we have to remove old image
                        var imagepath = Path.Combine(webRootpath, productvm.product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagepath))
                        {
                            System.IO.File.Delete(imagepath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    productvm.product.ImageUrl = @"\images\products\" + fileName + extension;
                }
                else
                {
                    //update when they do not change image Name
                    if (productvm.product.Id != 0)
                    {
                        Product objFromDb = _unitOfwork.product.Get(productvm.product.Id);
                        productvm.product.ImageUrl = objFromDb.ImageUrl;
                    }
                }

                if (productvm.product.Id == 0)
                {
                    _unitOfwork.product.Add(productvm.product);
                    return View(nameof(Index));
                }
                else
                {
                    _unitOfwork.product.Update(productvm.product);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(productvm);

        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfwork.product.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Something Went Wrong." });
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _unitOfwork.product.Remove(objFromDb);
            return Json(new { success = true, message = "Delete Success!" });
        }
    

        #endregion
    }
}

