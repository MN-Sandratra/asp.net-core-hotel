using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class OrderLineService : IOrderLine
    {
        private readonly BDDContext _dbContext;
        public OrderLineService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddOrderLine(OrderLine orderLine)
        {
            try
            {
                this._dbContext.OrderLines.Add(orderLine);
                this._dbContext.SaveChanges();
                return "Order line add successfully";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public List<OrderLine> getAllOrderLine()
        {
            return _dbContext.OrderLines.Include(p => p.art).ToList();
        }

        public OrderLine getOrderLineById(int id)
        {
            var ordLine = this._dbContext.OrderLines.Find(id);
            return ordLine;
        }

        public string RemoveOrderLine(int id)
        {
            try
            {
                var OrderLineToRemove = this.getOrderLineById(id);
                this._dbContext.OrderLines.Remove(OrderLineToRemove);
                this._dbContext.SaveChanges();
                return "Order line removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateOrderLine(int id, OrderLine orderLine)
        {
            try
            {
                var orderLineUpdate = this._dbContext.OrderLines.Find(id);
                if (orderLineUpdate != null)
                {
                    orderLineUpdate.qtCommander = orderLine.qtCommander;
                    orderLineUpdate.price = orderLine.price;
                    orderLineUpdate.amount = orderLine.amount;
                    orderLineUpdate.art = orderLine.art;

                    this._dbContext.SaveChanges();
                    return "Order line update successfully";
                }
                else
                {
                    return "No order line found";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
