using Realty_Biz.Repository.IRepository;
using Realty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Biz.Repository
{
    public class MockHouseRepository : IHouseRepository
    {
        private List<House> data;
        public MockHouseRepository()
        {
            data = new List<House>() {
                new House(){ Id = 1, Lot="111", Address="Москва, Загорьевская ул., 10", IsExclusive=true, IsMortagege=true, NumOfRoms=2, Squeare=121.7d, Price=890000.0d, RegionId=1 },
                new House(){ Id = 2, Lot="222", Address="Московская область, Химки, Ленинградское шоссе, 20-й километр", IsExclusive=false, IsMortagege=true, NumOfRoms=5, Squeare=135.0d, Price=740000.0d, RegionId=2 }
            };
        }

        public async Task<House> Create(House obj)
        {
            await Task.Delay(500);
            if (data.Where(x=> x.Lot == obj.Lot).Count() > 0)
            {
                throw new Exception("Элемент уже существует в списке.");
            }
            obj.Id = data.Max(p => p.Id) + 1;
            data.Add(obj);
            return obj;
        }

        public async Task<int> Delete(int id)
        {
            await Task.Delay(500);
            var obj = data.FirstOrDefault(p =>  p.Id == id);
            if (obj == null) return 0;
            return data.RemoveAll(x =>  x.Id == id);
        }

        public async Task<House> Get(int id)
        {
            await Task.Delay(500);
            var obj = data.FirstOrDefault(p => p.Id == id);
            House house = new House();
            if (obj != null)
            {
                house.Id = obj.Id;
                house.Lot = obj.Lot;
                house.Address = obj.Address;
                house.Notes = obj.Notes;
                house.IsExclusive = obj.IsExclusive;
                house.IsMortagege = obj.IsMortagege;
                house.Squeare = obj.Squeare;
                house.NumOfRoms = obj.NumOfRoms;
                house.Price = obj.Price;
                house.ImageUrl = obj.ImageUrl;
                house.RegionId = obj.RegionId;
            }
            return house;
        }

        public async Task<IEnumerable<House>> GetAll()
        {
            await Task.Delay(500);
            return data;
        }

        public async Task<House> Update(House obj)
        {
            await Task.Delay(500);
            var objFromDate = data.FirstOrDefault(p => p.Id == obj.Id);
            if (objFromDate != null)
            {
                objFromDate.Lot = obj.Lot;
                objFromDate.Address = obj.Address;
                objFromDate.Notes = obj.Notes;
                objFromDate.IsExclusive = obj.IsExclusive;
                objFromDate.IsMortagege = obj.IsMortagege;
                objFromDate.Squeare = obj.Squeare;
                objFromDate.NumOfRoms = obj.NumOfRoms;
                objFromDate.Price = obj.Price;
                objFromDate.ImageUrl = obj.ImageUrl;
                objFromDate.RegionId = obj.RegionId;
                data.Where(p => p.Id == obj.Id).ToList().ForEach(x => {
                    x.Lot = obj.Lot;
                    x.Address = obj.Address;
                    x.Notes = obj.Notes;
                    x.IsExclusive = obj.IsExclusive;
                    x.IsMortagege = obj.IsMortagege;
                    x.Squeare = obj.Squeare;
                    x.NumOfRoms = obj.NumOfRoms;
                    x.Price = obj.Price;
                    x.ImageUrl = obj.ImageUrl;
                    x.RegionId = obj.RegionId;
                });
                return objFromDate;
            }
            return obj;
        }
    }
}
