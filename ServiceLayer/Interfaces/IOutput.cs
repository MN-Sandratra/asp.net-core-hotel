using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IOutput
    {
        //get Output 
        List<Output> getAllOutput();
        //get Output by id
        Output getOutputById(int id);

        //add
        String AddOutput(Output output);
        //update
        String UpdateOutput(int id, Output output);
        //delete 
        String RemoveOutput(int id);
    }
}
