using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Compte
    {
        public int Id { get; set; }
        public int numeroCompte { get; set; }
        public String intituleCompte { get; set; }
        public int typecompteId { get; set; }
        public TypeCompte typecompte { get; set; }

        public int classecompteId { get; set; }
        public ClasseCompte classecompte { get; set; }
    }
}
