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
    [Route("api/Output")]
    public class OutputController : Controller
    {
        private readonly IOutput _output;

        public OutputController(IOutput output)
        {
            _output = output;
        }

        // GET api/output
        [HttpGet]
        public List<Output> Get()
        {
            return _output.getAllOutput();
        }

        // GET api/output/5
        [HttpGet("{id}")]
        public Output Get(int id)
        {
            return _output.getOutputById(id);
        }
        // POST api/output
        [HttpPost]
        public String Post([FromBody]Output output)
        {
            return this._output.AddOutput(output);
        }

        // PUT api/output/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Output output)
        {
            return this._output.UpdateOutput(id, output);
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._output.RemoveOutput(id);
        }
    }
}