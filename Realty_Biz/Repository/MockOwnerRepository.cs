using Realty_Biz.Repository.IRepository;
using Realty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace Realty_Biz.Repository
{
    public class MockOwnerRepository : IOwnerRepository
    {
        private List<Owner> data;

        public MockOwnerRepository()
        {
            data = new List<Owner>()
            {
                new Owner() { Id = 1, Fio = "Иванов И.М.", StartTitul = DateTime.Parse("06.06.1988", CultureInfo.GetCultureInfo("ru")), TypeTitul = "Собственность", NumTitul = "111-222", EndTitul = DateTime.Parse("15.10.2000", CultureInfo.GetCultureInfo("ru")), HouseId = 1 },
                new Owner() { Id = 2, Fio = "Петрова А.С.", StartTitul = DateTime.Parse("15.10.2000", CultureInfo.GetCultureInfo("ru")), TypeTitul = "Долевая собственность. 1/2 доли", NumTitul = "123-222.", HouseId = 1 },
                new Owner() { Id = 3, Fio = "Петров К.П.", StartTitul = DateTime.Parse("15.12.2002", CultureInfo.GetCultureInfo("ru")), TypeTitul = "Долевая собственность. 1/2 доли", NumTitul = "123-222.6", HouseId = 1 }
            };
        }

        public async Task<Owner> Create(Owner obj)
        {
            await Task.Delay(500);
            if (data.Where(x => x.NumTitul?.ToUpper() == obj.NumTitul?.ToUpper()).Count() > 0)
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
            var obj = data.FirstOrDefault(p => p.Id == id);
            if (obj == null) return 0;
            return data.RemoveAll(x => x.Id == id);
        }

        public async Task<Owner> Get(int id)
        {
            await Task.Delay(500);
            var obj = data.FirstOrDefault(p => p.Id == id);
            Owner owner = new Owner();
            if (obj != null)
            {
                owner.Id = obj.Id;
                owner.Fio = obj.Fio;
                owner.StartTitul = obj.StartTitul;
                owner.TypeTitul = obj.TypeTitul;
                owner.NumTitul = obj.NumTitul;
                owner.EndTitul = obj.EndTitul;
                owner.HouseId = obj.HouseId;
            }
            return owner;
        }

        public async Task<IEnumerable<Owner>> GetAll(int? id = null)
        {
            await Task.Delay(500);
            if (id != null && id > 0)
            {
                return data.Where(x => x.HouseId == id).ToList();
            }
            else
            {
                return data;
            }
        }

        public async Task<Owner> Update(Owner obj)
        {
            await Task.Delay(500);
            var objFromDate = data.FirstOrDefault(p => p.Id == obj.Id);
            if (objFromDate != null)
            {
                objFromDate.Fio = obj.Fio;
                objFromDate.StartTitul = obj.StartTitul;
                objFromDate.TypeTitul = obj.TypeTitul;
                objFromDate.NumTitul = obj.NumTitul;
                objFromDate.EndTitul = obj.EndTitul;
                objFromDate.HouseId = obj.HouseId;
                data.Where(p => p.Id == obj.Id).ToList().ForEach(x =>
                {
                    x.Fio = obj.Fio;
                    x.StartTitul = obj.StartTitul;
                    x.TypeTitul = obj.TypeTitul;
                    x.NumTitul = obj.NumTitul;
                    x.EndTitul = obj.EndTitul;
                    x.HouseId = obj.HouseId;
                });
                return objFromDate;
            }
            return obj;
        }
    }
}
