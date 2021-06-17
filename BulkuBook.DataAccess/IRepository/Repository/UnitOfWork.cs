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
        }


        public ICatagoryRepository catagory { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
