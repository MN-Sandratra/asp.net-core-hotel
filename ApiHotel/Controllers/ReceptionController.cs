using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace ApiHotel.Controllers
{
    [Produces("application/json")]
    [Route("api/Reception")]
    public class ReceptionController : Controller
    {
        private readonly IReception _reception;

        public ReceptionController(IReception reception)
        {
            _reception = reception;
        }

        // GET api/reception
        [HttpGet]
        public List<Reception> Get()
        {
            return _reception.getAllReception();
        }

        // GET api/reception/5
        [HttpGet("{id}")]
        public Reception Get(int id)
        {
            return _reception.getReceptionById(id);
        }
        // POST api/reception
        [HttpPost]
        public String Post([FromBody]Reception reception)
        {
            return this._reception.AddReception(reception);
        }

        // PUT api/reception/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Reception reception)
        {
            return this._reception.UpdateReception(id, reception);
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._reception.RemoveReception(id);
        }
    }
}