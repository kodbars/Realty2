using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realty_Models;

namespace Realty_Biz.Repository.IRepository
{
    public interface IRegionRepository
    {
        public Region Create(Region obj);
        public Region Update(Region obj);
        public int Delete(int id);
        public Region Get(int id);
        public IEnumerable<Region> GetAll();
    }
}
