using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface ICategory
    {
        //get category
        List<Category> getAllCategory();

        //get category by id
        Category getCategoryById(int id);

        //Add
        String AddCategory(Category cat);
        //update
        String UpdateCategory(int id, Category cat);
        //delete
        String RemoveCategory(int id);
    }
}
