﻿using BulkuBook.DataAccess.IRepository;
using BulkyBook.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatagoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CatagoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Catagory catagory = new Catagory();
            if(id == null)
            {
                //for create
                return View(catagory);
            }
            catagory = _unitOfWork.catagory.Get(id.GetValueOrDefault());
            if(catagory == null)
            {
                return NotFound();
            }
            return View(catagory);
        }


        #region ApiCalls
        [HttpGet]
        public IActionResult GetAll()
        {
            var obj =_unitOfWork.catagory.GetAll();
            return Json(new { data = obj });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                if(catagory.Id ==0)
                {
                    _unitOfWork.catagory.Add(catagory);
                }
                else
                {
                    _unitOfWork.catagory.Update(catagory);
                }        
            }
            return View(nameof(Index));
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.catagory.Get(id);
            if(obj == null)
            {
                return Json(new { success = false, message = "Something Went Wrong" });
            }
            _unitOfWork.catagory.Remove(obj);
            return Json(new { success = true, message = "Delete Success" });
        }
        #endregion
    }
}
