using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class OutputService : IOutput
    {
        private readonly BDDContext _dbContext;
        public OutputService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddOutput(Output output)
        {
            try
            {
                this._dbContext.Outputs.Add(output);
                this._dbContext.SaveChanges();
                return "Output add successfully";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public List<Output> getAllOutput()
        {
            return _dbContext.Outputs.ToList();
        }

        public Output getOutputById(int id)
        {
            var output = this._dbContext.Outputs.Find(id);
            return output;
        }

        public string RemoveOutput(int id)
        {
            try
            {
                var OutputToRemove = this.getOutputById(id);
                this._dbContext.Outputs.Remove(OutputToRemove);
                this._dbContext.SaveChanges();
                return "Output removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateOutput(int id, Output output)
        {
            try
            {
                var outputUpdate = this._dbContext.Outputs.Find(id);
                if (outputUpdate != null)
                {
                    outputUpdate.quantity = output.quantity;
                    outputUpdate.dateSortie = output.dateSortie;
                    outputUpdate.prixSortie = output.prixSortie;
                    outputUpdate.art = output.art;
                    this._dbContext.SaveChanges();
                    return "Output update successfully";
                }
                else
                {
                    return "No output found";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
