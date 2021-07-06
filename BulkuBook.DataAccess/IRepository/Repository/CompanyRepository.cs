using BulkyBook.Data;
using BulkyBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkuBook.DataAccess.IRepository.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
           var obj = _db.companies.Find(company.Id);
            if(obj != null)
            {
                obj.Name = company.Name;
                obj.StreetAddress = company.StreetAddress;
                obj.City = company.City;
                obj.State = company.State;
                obj.PostalCode = company.PostalCode;
                obj.IsAuthorized = company.IsAuthorized;
                obj.PhoneNumber = company.PhoneNumber;
                _db.SaveChanges();
            }
        }
    }
}
