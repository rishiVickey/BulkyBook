using BulkyBook.Data;
using BulkyBook.Model.Models;
using System.Linq;

namespace BulkuBook.DataAccess.IRepository.Repository
{
    public class CatagoryRepository : Repository<Catagory>, ICatagoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CatagoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Catagory entity)
        {
            Catagory obj = _db.Catagories.SingleOrDefault(p => p.Id == entity.Id);
            if(obj != null)
            {
                obj.Name = entity.Name;
                _db.SaveChanges();
            }
          
        }
    }
}
