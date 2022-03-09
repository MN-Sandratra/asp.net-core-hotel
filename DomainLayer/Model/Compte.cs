using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Compte
    {
        [Key]
        public int numeroCompte { get; set; }
        public String intituleCompte { get; set; }
        public TypeCompte typecompte { get; set; }
        public ClasseCompte classecompte { get; set; }
    }
}
