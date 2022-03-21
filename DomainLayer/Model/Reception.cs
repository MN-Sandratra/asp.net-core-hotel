using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Reception
    {
        [Key]
        public int id { get; set; }
        public DateTime dateReception { get; set; }
        public int ordId { get; set; }
        public Order ord { get; set; }
        public int qtLivrer { get; set; }

    }
}
