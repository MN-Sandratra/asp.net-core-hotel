using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IClasseCompte
    {
        List<ClasseCompte> GetAllClasseCompte();

        Boolean ExistClasseCompte(int id);

        ClasseCompte GetClasseCompteById(int id);

        String PostClasseCompte(ClasseCompte classecompte);

        String PutClasseCompte(int id, ClasseCompte classecompte);

        String DeleteClasseCompte(int id);
    }
}
