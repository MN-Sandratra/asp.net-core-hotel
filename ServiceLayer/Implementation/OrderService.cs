using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class OrderService : IOrder
    {
        private readonly BDDContext _dbContext;
        public OrderService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddOrder(Order order)
        {
            try
            {
                this._dbContext.Orders.Add(order);
                this._dbContext.SaveChanges();
                return "Order add successfully";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public List<Order> getAllOrder()
        {
            return _dbContext.Orders.ToList();
        }

        public Order getOrderById(int id)
        {
            var ord = this._dbContext.Orders.Find(id);
            return ord;
        }

        public string RemoveOrder(int id)
        {
            try
            {
                var OrderToRemove = this.getOrderById(id);
                this._dbContext.Orders.Remove(OrderToRemove);
                this._dbContext.SaveChanges();
                return "Order removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateOrder(int id, Order order)
        {
            try
            {
                var orderUpdate = this._dbContext.Orders.Find(id);
                if (orderUpdate != null)
                {
                    orderUpdate.dateCommande = order.dateCommande;
                    orderUpdate.state = order.state;
                    orderUpdate.ordline = order.ordline;
                    this._dbContext.SaveChanges();
                    return "Order update successfully";
                }
                else
                {
                    return "No order found";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
