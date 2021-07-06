using BulkuBook.DataAccess.IRepository;
using BulkyBook.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public CompanyController(IUnitOfWork UnitOfWork)
        {
            _unitOfwork = UnitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            var company = new Company();
            if(id == null)
            {
                return View(company);
            }
            company = _unitOfwork.Company.Get(id.GetValueOrDefault());
            if(company == null)
            {
                return NotFound();
            }
            return View(company);
        }






        #region Api calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = _unitOfwork.Company.GetAll();
            return Json(new { data = obj });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if(company.Id == 0)
                {
                    _unitOfwork.Company.Add(company);
                }
                else
                {
                    _unitOfwork.Company.Update(company);
                }
            }
            return View(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfwork.Company.Get(id);
            if(obj == null)
            {
                return Json(new { success = false, message = "Something went wrong!" });
            }
            _unitOfwork.Company.Remove(obj);
            return Json(new { success = true, message = "Delete Successful" });
        }



        #endregion
    }
}
