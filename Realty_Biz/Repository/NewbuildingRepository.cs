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
    public class NewbuildingRepository : INewbuildingRepository
    {
        private readonly AppDbContext _db;

        public NewbuildingRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Newbuilding> Create(Newbuilding obj)
        {
            _db.Newbuildings.Add(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Newbuildings.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Newbuildings.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Newbuilding> Get(int id)
        {
            var obj = await _db.Newbuildings.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return new Newbuilding();
        }

        public async Task<IEnumerable<Newbuilding>> GetAll()
        {

            return await _db.Newbuildings.ToListAsync();
        }

        public async Task<Newbuilding> Update(Newbuilding obj)
        {

            _db.Newbuildings.Update(obj);
            await _db.SaveChangesAsync();
            return obj;

        }
    }
}
