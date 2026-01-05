using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realty_Models;

namespace Realty_Biz.Repository.IRepository
{
    public interface IHouseRepository
    {
        public Task<House> Create(House obj);
        public Task<House> Update(House obj);
        public Task<int> Delete(int id);
        public Task<House> Get(int id);
        public Task<IEnumerable<House>> GetAll();
    }
}
