using BulkyBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkuBook.DataAccess.IRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            catagory = new CatagoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
        }


        public ICatagoryRepository catagory { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        public IProductRepository product { get; private set; }

        public ICompanyRepository Company { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
