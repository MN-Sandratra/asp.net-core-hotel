using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class ArticleCategoryService : IArticleCategory
    {
        private readonly BDDContext _dbContext;
        public ArticleCategoryService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddArticleCategory(ArticleCategory articleCategory)
        {
            try
            {
                this._dbContext.ArticleCategories.Add(articleCategory);
                this._dbContext.SaveChanges();
                return "Article Category add successfully";
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }

        public List<ArticleCategory> getAllArticleCategory()
        {
            return _dbContext.ArticleCategories.ToList();
        }

        public ArticleCategory getArticleCategoryById(int id)
        {
            var articleCat = this._dbContext.ArticleCategories.Find(id);
            return articleCat;
        }

        public string RemoveArticleCategory(int id)
        {
            try
            {
                var ArticleCategoryToRemove = this.getArticleCategoryById(id);
                this._dbContext.ArticleCategories.Remove(ArticleCategoryToRemove);
                this._dbContext.SaveChanges();
                return "Article Category removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string UpdateArticleCategory(int id, ArticleCategory articleCategory)
        {
            try
            {
                var articleCategoryUpdate = this._dbContext.ArticleCategories.Find(id);
                if (articleCategoryUpdate != null)
                {
                    articleCategoryUpdate.categoryName = articleCategory.categoryName;
                    articleCategoryUpdate.description = articleCategory.description;
                  

                    this._dbContext.SaveChanges();
                    return "Article category update successfully";
                }
                else
                {
                    return "No article category found";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
