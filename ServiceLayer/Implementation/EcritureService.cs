using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class EcritureService : IEcriture
    {
        private readonly BDDContext _dbContext;

        public EcritureService(BDDContext db)
        {
            _dbContext = db;
        }

        public List<Ecriture> GetAllEcriture()
        {
            return this._dbContext.Ecritures.ToList();
        }

        public Boolean ExistEcriture(int id)
        {
            return _dbContext.Ecritures.Any(e => e.Id == id);
        }

        public Ecriture GetEcritureById(int id)
        {
            return this._dbContext.Ecritures.Find(id);
        }

        public String PostEcriture(Ecriture ecriture)
        {
            try
            {
                this._dbContext.Ecritures.Add(ecriture);
                this._dbContext.SaveChanges();
                return "Ecriture ajouté avec succès";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public String PutEcriture(int id, Ecriture ecriture)
        {
            try
            {
                if (ExistEcriture(id))
                {
                    var EcritureUpdate = this.GetEcritureById(id);

                    EcritureUpdate.dateEcriture = ecriture.dateEcriture;
                    EcritureUpdate.libelleEcriture = ecriture.libelleEcriture;

                    this._dbContext.Ecritures.Update(EcritureUpdate);
                    this._dbContext.SaveChanges();
                    return "Mise à jour d'ecriture réussie";
                }
                else
                {
                    return "Ecriture invalide, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public String DeleteEcriture(int id)
        {
            try
            {
                if (ExistEcriture(id))
                {
                    var EcritureToRemove = this.GetEcritureById(id);
                    this._dbContext.Ecritures.Remove(EcritureToRemove);
                    this._dbContext.SaveChanges();
                    return "Ecriture supprimé avec succès";
                }
                else
                {
                    return "Ecriture introuvable, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
