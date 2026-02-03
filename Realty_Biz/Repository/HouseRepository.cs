using Microsoft.EntityFrameworkCore;
using Realty_Biz.Repository.IRepository;
using Realty_Db.Data;
using Realty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Biz.Repository
{
    public class HouseRepository : IHouseRepository
    {
        private readonly AppDbContext _db;

        public HouseRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<House> Create(House obj)
        {
            var addedObj = _db.Houses.Add(obj);
            await _db.SaveChangesAsync();
            return addedObj.Entity;
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Houses.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Houses.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<House> Get(int id)
        {
            var obj = await _db.Houses.Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return new House();
        }

        public async Task<IEnumerable<House>> GetAll()
        {
            return await _db.Houses.Include(x => x.Region).ToListAsync();
        }

        public async Task<House> Update(House obj)
        {
            _db.Houses.Update(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
    }
}
