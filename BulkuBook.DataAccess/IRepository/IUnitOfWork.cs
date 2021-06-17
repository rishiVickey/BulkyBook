using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkuBook.DataAccess.IRepository
{
   public interface IUnitOfWork :IDisposable
    {
        ICatagoryRepository catagory { get; }
    }
}
