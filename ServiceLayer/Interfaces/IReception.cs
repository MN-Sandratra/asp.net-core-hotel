using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IReception
    {
        //get Reception
        List<Reception> getAllReception();
        //get Reception by id
        Reception getReceptionById(int id);
        //add
        String AddReception(Reception reception);
        //update
        String UpdateReception(int id, Reception reception);
        //delete
        String RemoveReception(int id);
    }
}
