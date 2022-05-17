using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class CompteService : ICompte
    {
        private readonly BDDContext _dbContext;

        public CompteService(BDDContext db)
        {
            _dbContext = db;
        }

        public List<Compte> GetAllCompte()
        {
            return this._dbContext.Comptes.ToList();
        }

        public Boolean ExistCompte(int id)
        {
            return _dbContext.Comptes.Any(e => e.Id == id);
        }

        public Compte GetCompteById(int id)
        {
            return this._dbContext.Comptes.Find(id);
        }

        public String PostCompte(Compte compte)
        {
            try
            {
                this._dbContext.Comptes.Add(compte);
                this._dbContext.SaveChanges();
                return "Compte ajouté avec succès";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public String PutCompte(int id, Compte compte)
        {
            try
            {
                if(ExistCompte(id))
                {
                    var compteUpdate = this.GetCompteById(id);

                    compteUpdate.numeroCompte = compte.numeroCompte;
                    compteUpdate.intituleCompte = compte.intituleCompte;
                    compteUpdate.typecompteId = compte.typecompteId;
                    compteUpdate.classecompteId = compte.classecompteId;

                    this._dbContext.Comptes.Update(compteUpdate);
                    this._dbContext.SaveChanges();
                    return "Mise à jour du compte réussie";
                }
                else
                {
                    return "Compte invalide, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public String DeleteCompte(int id)
        {
            try
            {
                if (ExistCompte(id))
                {
                    var compteToRemove = this.GetCompteById(id);
                    this._dbContext.Comptes.Remove(compteToRemove);
                    this._dbContext.SaveChanges();
                    return "Compte supprimé avec succès";
                }
                else
                {
                    return "Compte introuvable, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
