using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IEcriture
    {
        List<Ecriture> GetAllEcriture();

        Boolean ExistEcriture(int id);

        Ecriture GetEcritureById(int id);

        String PostEcriture(Ecriture ecriture);

        String PutEcriture(int id, Ecriture ecriture);

        String DeleteEcriture(int id);
    }
}
