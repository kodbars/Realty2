using Realty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Biz.Repository.IRepository
{
    public interface INewbuildingRepository
    {
        public Task<Newbuilding> Create(Newbuilding obj);
        public Task<Newbuilding> Update(Newbuilding obj);
        public Task<int> Delete(int id);
        public Task<Newbuilding> Get(int id);
        public Task<IEnumerable<Newbuilding>> GetAll();
    }
}
