using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class ClasseCompte
    {
        public int Id { get; set; }
        public String nomClasse { get; set; }
        public int numeroClasse { get; set; }
    }
}
