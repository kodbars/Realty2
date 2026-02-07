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
    public class OwnerRepository : IOwnerRepository
    {
        IDbContextFactory<AppDbContext> _factory;

        public OwnerRepository(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<Owner> Create(Owner obj)
        {
            using var _db = _factory.CreateDbContext();
            try
            {
                var addedObj = _db.Owners.Add(obj);
                await _db.SaveChangesAsync();
                return addedObj.Entity;
            }
            catch (Exception ex)
            {
                _db.Entry(obj).State = EntityState.Unchanged;
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<int> Delete(int id)
        {
            using var _db = _factory.CreateDbContext();
            var obj = await _db.Owners.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Owners.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Owner> Get(int id)
        {
            using var _db = _factory.CreateDbContext();
            var obj = await _db.Owners.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return new Owner();
        }

        public async Task<IEnumerable<Owner>> GetAll(int? id = null)
        {
            using var _db = _factory.CreateDbContext();
            if (id != null && id > 0)
            {
                return await _db.Owners.Where(x => x.HouseId == id).ToListAsync();
            }
            else
            {
                return await _db.Owners.ToListAsync();
            }
        }

        public async Task<Owner> Update(Owner obj)
        {
            using var _db = _factory.CreateDbContext();
            try
            {
                _db.Owners.Update(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                _db.Entry(obj).State = EntityState.Detached;
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
