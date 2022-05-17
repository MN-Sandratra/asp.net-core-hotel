using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class TypeCompteService: ITypeCompte
    {
        private readonly BDDContext _dbContext;

        public TypeCompteService(BDDContext db)
        {
            _dbContext = db;
        }

        public List<TypeCompte> GetAllTypeCompte()
        {
            return this._dbContext.TypeComptes.ToList();
        }

        public Boolean ExistTypeCompte(int id)
        {
            return _dbContext.TypeComptes.Any(e => e.Id == id);
        }

        public TypeCompte GetTypeCompteById(int id)
        {
            return this._dbContext.TypeComptes.Find(id);
        }

        public String PostTypeCompte(TypeCompte typecompte)
        {
            try
            {
                this._dbContext.TypeComptes.Add(typecompte);
                this._dbContext.SaveChanges();
                return "Type compte ajouté avec succès";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public String PutTypeCompte(int id, TypeCompte typecompte)
        {
            try
            {
                if (ExistTypeCompte(id))
                {
                    var TypeCompteUpdate = this.GetTypeCompteById(id);

                    TypeCompteUpdate.nomTypeCompte = typecompte.nomTypeCompte;

                    this._dbContext.TypeComptes.Update(TypeCompteUpdate);
                    this._dbContext.SaveChanges();
                    return "Mise à jour du type compte réussie";
                }
                else
                {
                    return "Type compte invalide, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public String DeleteTypeCompte(int id)
        {
            try
            {
                if (ExistTypeCompte(id))
                {
                    var TypeCompteToRemove = this.GetTypeCompteById(id);
                    this._dbContext.TypeComptes.Remove(TypeCompteToRemove);
                    this._dbContext.SaveChanges();
                    return "Type compte supprimé avec succès";
                }
                else
                {
                    return "Type compte introuvable, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
