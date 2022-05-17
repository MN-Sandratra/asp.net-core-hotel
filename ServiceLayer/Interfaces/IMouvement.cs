using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IMouvement
    {
        List<Mouvement> GetAllMouvement();

        Boolean ExistMouvement(int id);

        Mouvement GetMouvementById(int id);

        String PostMouvement(Mouvement mouvement);

        String PutMouvement(int id, Mouvement mouvement);

        String DeleteMouvement(int id);

        IQueryable Select1apls();
    }
}
