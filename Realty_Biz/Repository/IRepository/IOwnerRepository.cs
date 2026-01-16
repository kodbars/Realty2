using Realty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Biz.Repository.IRepository
{
    public interface IOwnerRepository
    {
        public Task<Owner> Create(Owner obj);
        public Task<Owner> Update(Owner obj);
        public Task<int> Delete(int id);
        public Task<Owner> Get(int id);
        public Task<IEnumerable<Owner>> GetAll(int? id = null);
    }
}
