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
    public class RegionRepository : IRegionRepository
    {
        IDbContextFactory<AppDbContext> _factory;

        public RegionRepository(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<Region> Create(Region obj)
        {
            using var _db = _factory.CreateDbContext();
            var addedObj = _db.Regions.Add(obj);
            await _db.SaveChangesAsync();
            return addedObj.Entity;
        }

        public async Task<int> Delete(int id)
        {
            using var _db = _factory.CreateDbContext();
            var obj = await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null) 
            {
                _db.Regions.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Region> Get(int id)
        {
            using var _db = _factory.CreateDbContext();
            var obj = await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return new Region();
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            using var _db = _factory.CreateDbContext();
            return await _db.Regions.ToListAsync();
        }

        public async Task<Region> Update(Region obj)
        {
            using var _db = _factory.CreateDbContext();
            _db.Regions.Update(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
    }
}
