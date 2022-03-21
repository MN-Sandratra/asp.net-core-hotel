using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class SupplierService : ISupplier
    {
        private readonly BDDContext _dbContext;
        public SupplierService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddSupplier(Supplier sup)
        {
            try
            {
                this._dbContext.Suppliers.Add(sup);
                this._dbContext.SaveChanges();
                return "Supplier add successfully";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

       

        public List<Supplier> getAllSupplier()
        {
            return _dbContext.Suppliers.ToList();
        }

        public Supplier getSupplierById(int id)
        {
            var supplier = this._dbContext.Suppliers.Find(id);
            return supplier;
        }

        public string RemoveSupplier(int id)
        {
            try
            {
                var SupplierToRemove = this.getSupplierById(id);
                this._dbContext.Suppliers.Remove(SupplierToRemove);
                this._dbContext.SaveChanges();
                return "Supplier removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateSupplier(int id, Supplier sup)
        {
            try
            {
                var supplierUpdate = this._dbContext.Suppliers.Find(id);
                if (supplierUpdate != null)
                {
                    supplierUpdate.supplierName = sup.supplierName;
                    supplierUpdate.adress = sup.adress;
                    supplierUpdate.codePost = sup.codePost;
                    supplierUpdate.phone= sup.phone;
                    supplierUpdate.email = sup.email;

                    this._dbContext.SaveChanges();
                    return "Supplier update successfully";
                }
                else
                {
                    return "No supplier found";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
