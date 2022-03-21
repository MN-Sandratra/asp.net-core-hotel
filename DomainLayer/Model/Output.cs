using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Output
    {
        [Key]
        public int id { get; set; }
        public int quantity { get; set; }
        public DateTime dateSortie { get; set; }
        public int artId { get; set; }
        public Article art { get; set; }
        public double prixSortie { get; set; }
    }
}
