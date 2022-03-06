using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Person
    {
        [Key]
        public int id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String CIN { get; set; }
        public String phone { get; set; }
    }
}
