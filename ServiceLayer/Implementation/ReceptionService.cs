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
    public class ReceptionService : IReception
    {
        private readonly BDDContext _dbContext;
        public ReceptionService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddReception(Reception reception)
        {
            try
            {
                this._dbContext.Receptions.Add(reception);
                this._dbContext.SaveChanges();
                return "Reception add successfully";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public List<Reception> getAllReception()
        {
            return _dbContext.Receptions.Include(p => p.ord).ToList();
        }

        public Reception getReceptionById(int id)
        {
            var recept = this._dbContext.Receptions.Find(id);
            return recept;
        }

        public string RemoveReception(int id)
        {
            try
            {
                var ReceptionToRemove = this.getReceptionById(id);
                this._dbContext.Receptions.Remove(ReceptionToRemove);
                this._dbContext.SaveChanges();
                return "Reception removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateReception(int id, Reception  reception)
        {
            try
            {
                var receptionUpdate = this._dbContext.Receptions.Find(id);
                if (receptionUpdate != null)
                {
                    receptionUpdate.dateReception = reception.dateReception;
                    receptionUpdate.qtLivrer = reception.qtLivrer;
                    receptionUpdate.ord = reception.ord;
                    this._dbContext.SaveChanges();
                    return "Reception update successfully";
                }
                else
                {
                    return "No reception found";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
