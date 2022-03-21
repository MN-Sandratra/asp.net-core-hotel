using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace ApiHotel.Controllers
{
    [Produces("application/json")]
    [Route("api/ArticleCategory")]
    public class ArticleCategoryController : Controller
    {
        private readonly IArticleCategory _articleCategory;

        public ArticleCategoryController(IArticleCategory articleCategory)
        {
            _articleCategory = articleCategory;
        }

        // GET api/articleCategory
        [HttpGet]
        public List<ArticleCategory> Get()
        {
            return _articleCategory.getAllArticleCategory();
        }

        // GET api/articleCategory/5
        [HttpGet("{id}")]
        public ArticleCategory Get(int id)
        {
            return _articleCategory.getArticleCategoryById(id);
        }
        // POST api/articleCategory
        [HttpPost]
        public String Post([FromBody]ArticleCategory articleCategory)
        {
            return this._articleCategory.AddArticleCategory(articleCategory);
        }

        // PUT api/articleCategory/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]ArticleCategory articleCategory)
        {
            return this._articleCategory.UpdateArticleCategory(id, articleCategory);
        }

        // DELETE api/articleCategory/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._articleCategory.RemoveArticleCategory(id);
        }
    }
}