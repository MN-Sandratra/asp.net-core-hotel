using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IOrderLine
    {
        //get OrderLine
        List<OrderLine> getAllOrderLine();
        //get OrderLine by id
        OrderLine getOrderLineById(int id);
        //add
        String AddOrderLine(OrderLine orderLine);
        //update
        String UpdateOrderLine(int id, OrderLine orderLine);
        //delete
        String RemoveOrderLine(int id);

    }
}
