using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class ArticleCategory
    { 
        [Key]
        public int id { get; set; }
        public String categoryName { get; set; }
        public String description { get; set; }
    }
}
