using Microsoft.AspNetCore.Mvc;
using Realty_Biz.Repository.IRepository;
using Realty_Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealtyWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewbuildingController : ControllerBase
    {
        private readonly INewbuildingRepository _newbuilding;

        public NewbuildingController(INewbuildingRepository newbuilding)
        {
            _newbuilding = newbuilding;
        }

        // GET: api/<NewbuildingController>
        [HttpGet]
        public async Task<IEnumerable<Newbuilding>> GetAll()
        {
            return await _newbuilding.GetAll();
        }

        // GET api/<NewbuildingController>/5
        [HttpGet("{id}")]
        public async Task<Newbuilding> Get(int id)
        {
            return await _newbuilding.Get(id); ;
        }

        // POST api/<NewbuildingController>
        [HttpPost]
        public async Task<Newbuilding> AddNewbuilding([FromBody] Newbuilding newbuilding)
        {
            return await _newbuilding.Create(newbuilding);
        }

        // PUT api/<NewbuildingController>/5
        [HttpPut("{id}")]
        public async Task<bool> UpdateNewbuilding(int id, [FromBody] Newbuilding newbuilding)
        {
            var data = await _newbuilding.Get(id);
            if (data != null)
            {
                data.NameHouse = newbuilding.NameHouse;
                data.TypeHouse = newbuilding.TypeHouse;
                data.Address = newbuilding.Address;
                data.YearOfDelivery = newbuilding.YearOfDelivery;
                data.NumOfApart = newbuilding.NumOfApart;
                data.NumOfStoreys = newbuilding.NumOfStoreys;
                data.IsParking = newbuilding.IsParking;
                await _newbuilding.Update(data);
                return true;
            }
            else
                return false;
        }

        // DELETE api/<NewbuildingController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteNewbuilding(int id)
        {
            var del_rows = await _newbuilding.Delete(id);
            return del_rows > 0 ? true : false;
        }
    }
}
