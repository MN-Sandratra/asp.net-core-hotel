using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
   public interface IInput
    {
        // get Input
        List<Input> getAllInput();
        //get Input by id
        Input getInputById(int id);
        //add
        String AddInput(Input input);
        //update
        String UpdateInput(int id, Input input);
        //delete
        String RemoveInput(int id);
    }
}
