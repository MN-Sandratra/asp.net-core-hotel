using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Room
    {
        [Key]
        public int number { get; set; }
        public Category category { get; set; }
        public String type { get; set; }
        public Double price { get; set; }
    }
}
