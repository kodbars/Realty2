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
        private readonly AppDbContext _db;

        public RegionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Region> Create(Region obj)
        {
            var addedObj = _db.Regions.Add(obj);
            await _db.SaveChangesAsync();
            return addedObj.Entity;
        }

        public async Task<int> Delete(int id)
        {
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
            var obj = await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return new Region();
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await _db.Regions.ToListAsync();
        }

        public async Task<Region> Update(Region obj)
        {
            _db.Regions.Update(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
    }
}
