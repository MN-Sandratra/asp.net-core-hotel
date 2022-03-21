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
    [Route("api/Input")]
    public class InputController : Controller
    {
        private readonly IInput _input;

        public InputController(IInput input)
        {
            _input = input;
        }

        // GET api/input
        [HttpGet]
        public List<Input> Get()
        {
            return _input.getAllInput();
        }

        // GET api/input/5
        [HttpGet("{id}")]
        public Input Get(int id)
        {
            return _input.getInputById(id);
        }
        // POST api/input
        [HttpPost]
        public String Post([FromBody]Input input)
        {
            return this._input.AddInput(input);
        }

        // PUT api/input/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Input input)

        {
            return this._input.UpdateInput(id, input);
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._input.RemoveInput(id);
        }
    }
}