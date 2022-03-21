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
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }

        // GET api/order
        [HttpGet]
        public List<Order> Get()
        {
            return _order.getAllOrder();
        }

        // GET api/order/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _order.getOrderById(id);
        }
        // POST api/order
        [HttpPost]
        public String Post([FromBody]Order order)
        {
            return this._order.AddOrder(order);
        }

        // PUT api/order/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Order order)
        {
            return this._order.UpdateOrder(id, order);
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._order.RemoveOrder(id);
        }
    }
}