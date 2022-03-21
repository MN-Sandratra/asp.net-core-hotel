using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IArticleCategory
    {
        //get ArticleCategory
        List<ArticleCategory> getAllArticleCategory();

        //get ArticleCategory by id
        ArticleCategory getArticleCategoryById(int id);
        //add
        String AddArticleCategory(ArticleCategory  articleCategory);
        //update
        String UpdateArticleCategory(int id, ArticleCategory articleCategory);
        //delete
        String RemoveArticleCategory(int id);
    }
}
