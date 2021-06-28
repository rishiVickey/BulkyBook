using BulkyBook.Data;
using BulkyBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkuBook.DataAccess.IRepository.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType cover)
        {
            var obj = _db.coverTypes.SingleOrDefault(p => p.Id == cover.Id);
            if(obj != null)
            {
                obj.Name = cover.Name;
                _db.SaveChanges();
            }
        }
    }
}
