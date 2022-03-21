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
    [Route("api/Supplier")]
    public class SupplierController : Controller
    {
        private readonly ISupplier _supplier;

        public SupplierController(ISupplier supplier)
        {
            _supplier = supplier;
        }

        // GET api/supplier
        [HttpGet]
        public List<Supplier> Get()
        {
            return _supplier.getAllSupplier();
        }

        // GET api/supplier/5
        [HttpGet("{id}")]
        public Supplier Get(int id)
        {
            return _supplier.getSupplierById(id);
        }
        // POST api/supplier
        [HttpPost]
        public String Post([FromBody]Supplier supplier)
        {
            return this._supplier.AddSupplier(supplier);
        }

        // PUT api/supplier/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Supplier supplier)
        {
            return this._supplier.UpdateSupplier(id, supplier);
        }

        // DELETE api/supplier/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._supplier.RemoveSupplier(id);
        }
    }
}