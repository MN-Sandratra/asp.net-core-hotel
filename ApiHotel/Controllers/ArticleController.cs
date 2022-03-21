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
    [Route("api/Article")]
    public class ArticleController : Controller
    {
        private readonly IArticle _article;

        public ArticleController(IArticle article)
        {
            _article= article;
        }

        // GET api/article
        [HttpGet]
        public List<Article> Get()
        {
            return _article.getAllArticle();
        }

        // GET api/article/5
        [HttpGet("{id}")]
        public Article Get(int id)
        {
            return _article.getArticleById(id);
        }
        // POST api/article
        [HttpPost]
        public String Post([FromBody]Article article)
        {
            return this._article.AddArticle(article);
        }

        // PUT api/article/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Article article)
        {
            return this._article.UpdateArticle(id, article);
        }

        // DELETE api/article/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._article.RemoveArticle(id);
        }
    }
}