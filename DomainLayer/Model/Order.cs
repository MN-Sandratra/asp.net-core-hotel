using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public DateTime dateCommande { get; set; }
        public int ordlineId { get; set; }
        public OrderLine ordline { get; set; }
        public String state { get; set; }
    } 
}
