using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Supplier
    {
        [Key]
        public int id { get; set; }
        public String supplierName { get; set; }
        public String adress { get; set; }
        public int codePost { get; set; }
        public String phone { get; set; }
        public String email { get; set; }


    }
}
