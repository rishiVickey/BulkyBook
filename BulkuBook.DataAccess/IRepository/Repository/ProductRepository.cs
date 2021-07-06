using BulkyBook.Data;
using BulkyBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkuBook.DataAccess.IRepository.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var obj = _db.products.SingleOrDefault(i => i.Id == product.Id);
            if (obj != null)
            {
                if (product.ImageUrl != null)
                {
                    obj.ImageUrl = product.ImageUrl;
                }
                obj.Title = product.Title;
                obj.ISBN = product.ISBN;
                obj.Price = product.Price;
                obj.Price50 = product.Price50;
                obj.Price100 = product.Price100;
                obj.Description = product.Description;
                obj.CatagoryId = product.CatagoryId;
                obj.CoverTypeId = product.CoverTypeId;
                obj.Author = product.Author;
                _db.SaveChanges();
            }
        }
    }
}
