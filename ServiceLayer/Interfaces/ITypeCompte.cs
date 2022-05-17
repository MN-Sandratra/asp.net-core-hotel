using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface ITypeCompte
    {
        List<TypeCompte> GetAllTypeCompte();

        Boolean ExistTypeCompte(int id);

        TypeCompte GetTypeCompteById(int id);

        String PostTypeCompte(TypeCompte typecompte);

        String PutTypeCompte(int id, TypeCompte typecompte);

        String DeleteTypeCompte(int id);
    }
}
