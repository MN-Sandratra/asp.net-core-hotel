using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IArticle
    {
        //get Article
        List<Article> getAllArticle();

        //get article by id
        Article getArticleById(int id);

        //add
        String AddArticle(Article art);

        //update 
        String UpdateArticle(int id, Article art);

        //delete
        String RemoveArticle(int id);

    }
}
