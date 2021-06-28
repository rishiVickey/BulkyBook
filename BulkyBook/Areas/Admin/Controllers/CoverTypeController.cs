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
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public CoverTypeController(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();
            if(id == null)
            {
                return View(coverType);
            }
            coverType = _unitOfwork.CoverType.Get(id.GetValueOrDefault());
            if(coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        #region APi Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = _unitOfwork.CoverType.GetAll();
            return Json(new { data = obj });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType cover)
        {
            if (ModelState.IsValid)
            {
                if (cover.Id == 0)
                {
                    _unitOfwork.CoverType.Add(cover);
                }
                else
                {
                    _unitOfwork.CoverType.Update(cover);
                }
            }
            return View(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfwork.CoverType.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Something Went Wrong" });
            }
            else
            {
                _unitOfwork.CoverType.Remove(obj);
                return Json(new { success = true, message = "Delete Success" });
            }
        }

        #endregion
    }
}
