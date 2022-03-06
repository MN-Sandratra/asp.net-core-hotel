using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public String designation { get; set; }
        public String description { get; set; }
        public double price { get; set; }
    }
}
