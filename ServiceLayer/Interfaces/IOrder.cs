using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IOrder
    {
        //get Order
        List<Order> getAllOrder();
        // get Order by id
        Order getOrderById(int id);
        //add
        String AddOrder(Order order);
        //update
        String UpdateOrder(int id, Order order);
        //delete 
        String RemoveOrder(int id);

    }
}
