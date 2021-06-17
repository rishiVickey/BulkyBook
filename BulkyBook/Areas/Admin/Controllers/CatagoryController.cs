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


        #region ApiCalls
        [HttpGet]
        public IEnumerable<Catagory> GetAll()
        {
            return _unitOfWork.catagory.GetAll();
        }

        #endregion
    }
}
