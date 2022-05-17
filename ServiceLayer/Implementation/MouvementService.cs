using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class MouvementService : IMouvement
    {
        private readonly BDDContext _dbContext;

        public MouvementService(BDDContext db)
        {
            _dbContext = db;
        }

        public List<Mouvement> GetAllMouvement()
        {
            return this._dbContext.Mouvements.ToList();
        }

        public Boolean ExistMouvement(int id)
        {
            return _dbContext.Mouvements.Any(e => e.Id == id);
        }

        public Mouvement GetMouvementById(int id)
        {
            return this._dbContext.Mouvements.Find(id);
        }

        public String PostMouvement(Mouvement mouvement)
        {
            try
            {
                this._dbContext.Mouvements.Add(mouvement);
                this._dbContext.SaveChanges();
                return "Mouvement ajouté avec succès";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public String PutMouvement(int id, Mouvement mouvement)
        {
            try
            {
                if (ExistMouvement(id))
                {
                    var MouvementUpdate = this.GetMouvementById(id);

                    MouvementUpdate.compteId = mouvement.compteId;
                    MouvementUpdate.credit = mouvement.credit;
                    MouvementUpdate.debit = mouvement.debit;
                    MouvementUpdate.ecritureId = mouvement.ecritureId;

                    this._dbContext.Mouvements.Update(MouvementUpdate);
                    this._dbContext.SaveChanges();
                    return "Mise à jour du mouvement réussie";
                }
                else
                {
                    return "Mouvement invalide, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public String DeleteMouvement(int id)
        {
            try
            {
                if (ExistMouvement(id))
                {
                    var MouvementToRemove = this.GetMouvementById(id);
                    this._dbContext.Mouvements.Remove(MouvementToRemove);
                    this._dbContext.SaveChanges();
                    return "Mouvement supprimé avec succès";
                }
                else
                {
                    return "Mouvement introuvable, veuillez vérifier";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public IQueryable Select1apls()
        {
            return from compte in _dbContext.Comptes
                   select new
                   {
                       classecompteByCompte =                           //classecompte
                       (
                            from classecompte in _dbContext.ClasseComptes
                            where compte.classecompteId == classecompte.Id
                            select new
                            {
                                classecompte.nomClasse,
                                classecompte.numeroClasse
                            }
                       ).ToList(),

                       typecompteByCompte =                             //typecompte
                       (
                            from typecompte in _dbContext.TypeComptes
                            where compte.typecompteId == typecompte.Id
                            select new
                            {
                                typecompte.nomTypeCompte
                            }
                       ).ToList(),

                       compte_mouvement_ecriture =
                       (
                           from mouvement in _dbContext.Mouvements
                           join ecriture in _dbContext.Ecritures
                           on mouvement.ecritureId equals ecriture.Id

                           where compte.Id == mouvement.compteId //izay id compte liée @mvt #compteId

                           select new
                           {
                               compte.numeroCompte,         //compte ny isan'ny donnée compte no alain fona
                               compte.intituleCompte,
                               
                               mouvement.Id,                //mouvement
                               mouvement.credit,
                               mouvement.debit,

                               ecriture.libelleEcriture,    //ecriture
                               ecriture.dateEcriture
                           }
                       ).ToList()
                   };
        }
    }
}
