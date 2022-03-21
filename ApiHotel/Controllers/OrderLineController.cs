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
    [Route("api/OrderLine")]
    public class OrderLineController : Controller
    {
        private readonly IOrderLine _orderLine;

        public OrderLineController(IOrderLine orderLine)
        {
            _orderLine = orderLine;
        }

        // GET api/ orderLine
        [HttpGet]
        public List<OrderLine> Get()
        {
            return _orderLine.getAllOrderLine();
        }

        // GET api/orderLine/5
        [HttpGet("{id}")]
        public OrderLine Get(int id)
        {
            return _orderLine.getOrderLineById(id);
        }
        // POST api/ orderLine
        [HttpPost]
        public String Post([FromBody]OrderLine orderLine)
        {
            return this._orderLine.AddOrderLine(orderLine);
        }

        // PUT api/orderLine/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]OrderLine orderLine)
        {
            return this._orderLine.UpdateOrderLine(id, orderLine);
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._orderLine.RemoveOrderLine(id);
        }
    }
}