using Realty_Biz.Repository.IRepository;
using Realty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Biz.Repository
{
    public class MockRegionRepository : IRegionRepository
    {
        private List<Region> _data;

        public MockRegionRepository()
        {
            _data = new List<Region>()
            {
                new Region() {Id = 1, Nm = "Москва", GIBDD = "77"},
                new Region() {Id = 2, Nm = "Московсая область", GIBDD = "50"},
                new Region() {Id = 3, Nm = "Санкт_Петербург", GIBDD = "78"}
            };
        }

        public Region Create(Region obj)
        {
            Thread.Sleep(500);
            if (_data.Where(x => x.Nm?.ToUpper() == obj.Nm.ToUpper()).Count() > 0)
            {
                throw new Exception("Элемент уже существует в списке.");
            }
            _data.Add(obj);
            return obj;
        }

        public int Delete(int id)
        {
            Thread.Sleep(500);
            var obj = _data.FirstOrDefault(p => p.Id == id);
            if (obj == null)
            {
                return 0; 
            }
            return _data.RemoveAll(x => x.Id == id);
        }

        public Region Get(int id)
        {
            Thread.Sleep(500);
            var obj = _data.FirstOrDefault(p => p.Id == id);
            return obj ?? new Region();
        }

        public IEnumerable<Region> GetAll()
        {
            Thread.Sleep(500);
            return _data;
        }

        public Region Update(Region obj)
        {
            Thread.Sleep(500);
            var objFromData = _data.FirstOrDefault(p => p.Id == obj.Id);
            if (objFromData != null) 
            {
                objFromData.Nm = obj.Nm;
                objFromData.GIBDD = obj.GIBDD;
                _data.Where(p => p.Id == obj.Id).ToList().ForEach(x => { x.Nm = obj.Nm; x.GIBDD = obj.GIBDD; });
                return objFromData;
            }
            return obj;
        }
    }
}
