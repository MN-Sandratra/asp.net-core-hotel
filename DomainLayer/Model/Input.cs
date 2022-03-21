using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Input
    {
        [Key]
        public int id { get; set; }
        public int quantity { get; set; }
        public DateTime dateEntree { get; set; }
        public int artId { get; set; }
        public Article art { get; set; }
        public double prixEntree { get; set; }
    }
}
