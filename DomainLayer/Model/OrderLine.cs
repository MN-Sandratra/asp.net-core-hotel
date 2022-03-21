using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class OrderLine
    { 
        [Key]
        public int id { get; set; }
        public int qtCommander { get; set; }
        public int artId { get; set; }
        public Article art { get; set; }
        public double price { get; set; }
        public double amount { get; set; }
    }
}
