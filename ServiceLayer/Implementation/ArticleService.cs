using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class ArticleService : IArticle

    {
        private readonly BDDContext _dbContext;
        public ArticleService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddArticle(Article art)
        {
            try
            {
                this._dbContext.Articles.Add(art);
                this._dbContext.SaveChanges();
                return "Article add successfully";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public List<Article> getAllArticle()
        {
            return _dbContext.Articles.Include(p=>p.artCat).ToList();
        }

        public Article getArticleById(int id)
        {
            var article = this._dbContext.Articles.Find(id);
            return article;
        }

        public string RemoveArticle(int id)
        {
        try
        {
            var ArticleToRemove = this.getArticleById(id);
            this._dbContext.Articles.Remove(ArticleToRemove);
            this._dbContext.SaveChanges();
            return "Article removed successfully";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

        public string UpdateArticle(int id, Article art)
        {
        try
        {
            var articleUpdate = this._dbContext.Articles.Find(id);
            if (articleUpdate != null)
            {
                articleUpdate.designation = art.designation;
                articleUpdate.unity = art.unity;
                articleUpdate.prix = art.prix;
                articleUpdate.quantity = art.quantity;
                articleUpdate.artCat = art.artCat;


                this._dbContext.SaveChanges();
                return "Article update successfully";
            }
            else
            {
                return "No article found";
            }
        }
        catch (Exception e)
        {

            return e.Message;
        }
    }
    }
}
