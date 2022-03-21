using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface ISupplier
    {
        //get Supplier
        List<Supplier> getAllSupplier();
        //get Supplier by id
        Supplier getSupplierById(int id);
        //add
        String AddSupplier(Supplier sup);
        //update
        String UpdateSupplier(int id, Supplier sup);
        //delete
        String RemoveSupplier(int id);
    }
}
