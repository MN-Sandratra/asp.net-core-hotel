using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class ClasseCompteService:IClasseCompte
    {
        private readonly BDDContext _dbContext;

        public ClasseCompteService(BDDContext db)
        {
            _dbContext = db;
        }

        public List<ClasseCompte> GetAllClasseCompte()
        {
            return this._dbContext.ClasseComptes.ToList();
        }

        public Boolean ExistClasseCompte(int id)
        {
            return _dbContext.ClasseComptes.Any(e => e.Id == id);
        }

        public ClasseCompte GetClasseCompteById(int id)
        {
            return this._dbContext.ClasseComptes.Find(id);
        }

        public String PostClasseCompte(ClasseCompte classecompte)
        {
            try
            {
                this._dbContext.ClasseComptes.Add(classecompte);
                this._dbContext.SaveChanges();
                return "Classe compte ajouté avec succès";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public String PutClasseCompte(int id, ClasseCompte classecompte)
        {
            try
            {
                if (ExistClasseCompte(id))
                {
                    var ClasseCompteUpdate = this.GetClasseCompteById(id);

                    ClasseCompteUpdate.nomClasse = classecompte.nomClasse;
                    ClasseCompteUpdate.numeroClasse = classecompte.numeroClasse;

                    this._dbContext.ClasseComptes.Update(ClasseCompteUpdate);
                    this._dbContext.SaveChanges();
                    return "Mise à jour du classe compte réussie";
                }
                else
                {
                    return "Classe compte invalide, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public String DeleteClasseCompte(int id)
        {
            try
            {
                if (ExistClasseCompte(id))
                {
                    var ClasseCompteToRemove = this.GetClasseCompteById(id);
                    this._dbContext.ClasseComptes.Remove(ClasseCompteToRemove);
                    this._dbContext.SaveChanges();
                    return "Classe compte supprimé avec succès";
                }
                else
                {
                    return "Classe compte introuvable, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
