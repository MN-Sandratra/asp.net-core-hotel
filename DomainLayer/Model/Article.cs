using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Article
    {
        [Key]
        public int id { get; set; }
        public String designation { get; set; }
        public String unity { get; set; }
        public double prix { get; set; }
        public int artCatId { get; set; }
        public ArticleCategory artCat { get; set; }
        public int quantity { get; set; }
    }
}
