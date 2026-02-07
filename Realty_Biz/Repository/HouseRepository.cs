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
        IDbContextFactory<AppDbContext> _factory;

        public HouseRepository(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }


        public async Task<House> Create(House obj)
        {
            using var _db = _factory.CreateDbContext();
            var addedObj = _db.Houses.Add(obj);
            await _db.SaveChangesAsync();
            return addedObj.Entity;
        }

        public async Task<int> Delete(int id)
        {
            using var _db = _factory.CreateDbContext();
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
            using var _db = _factory.CreateDbContext();
            var obj = await _db.Houses.Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return new House();
        }

        public async Task<IEnumerable<House>> GetAll()
        {
            using var _db = _factory.CreateDbContext();
            return await _db.Houses.Include(x => x.Region).ToListAsync();
        }

        public async Task<House> Update(House obj)
        {
            using var _db = _factory.CreateDbContext();
            if (await _db.Houses.FirstOrDefaultAsync(x => x.Id == obj.Id) is House found)
            {
                _db.Entry(found).CurrentValues.SetValues(obj);
                await _db.SaveChangesAsync();
            }
            return obj;
        }
    }
}
