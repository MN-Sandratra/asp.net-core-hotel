using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface ICompte
    {
        List<Compte> GetAllCompte();

        Boolean ExistCompte(int id);

        Compte GetCompteById(int id);

        String PostCompte(Compte compte);

        String PutCompte(int id, Compte compte);

        String DeleteCompte(int id);
    }
}
