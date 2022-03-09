using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Model
{
    public class Mouvement
    {
        public int Id { get; set; }
        public Compte compte { get; set; }
        public Ecriture ecriture { get; set; }
        public Double debit { get; set; }
        public Double credit { get; set; }
    }
}
