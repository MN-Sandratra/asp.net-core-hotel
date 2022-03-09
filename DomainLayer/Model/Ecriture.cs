using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Ecriture
    {
        public int Id { get; set; }
        public String libelleEcriture { get; set; }
        public DateTime dateEcriture { get; set; }
    }
}
