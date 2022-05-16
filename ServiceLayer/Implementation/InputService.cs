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
    public class InputService : IInput
    {
        private readonly BDDContext _dbContext;
        public InputService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddInput(Input input)
        {
            try
            {
                this._dbContext.Inputs.Add(input);
                this._dbContext.SaveChanges();
                return "Input add successfully";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public List<Input> getAllInput()
        {
            return _dbContext.Inputs.Include(p => p.art).ToList();
        }

        public Input getInputById(int id)
        {
            var inp = this._dbContext.Inputs.Find(id);
            return inp;
        }

        public string RemoveInput(int id)
        {
            try
            {
                var InputToRemove = this.getInputById(id);
                this._dbContext.Inputs.Remove(InputToRemove);
                this._dbContext.SaveChanges();
                return "Input removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateInput(int id, Input input)
        {
            try
            {
                var inputUpdate = this._dbContext.Inputs.Find(id);
                if (inputUpdate != null)
                {
                    inputUpdate.quantity = input.quantity;
                    inputUpdate.dateEntree = input.dateEntree;
                    inputUpdate.prixEntree = input.prixEntree;
                    inputUpdate.art = input.art;

                    this._dbContext.SaveChanges();
                    return "Input update successfully";
                }
                else
                {
                    return "No input found";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
