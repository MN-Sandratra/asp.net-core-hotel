using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class CategoryService : ICategory
    {
        private readonly BDDContext _dbContext;

        public CategoryService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddCategory(Category cath)
        {
            try
            {
                this._dbContext.Category.Add(cath);
                this._dbContext.SaveChanges();
                return "Category add successfully";

            }catch(Exception e)
            {
                return e.Message;
            }
        }

        public List<Category> getAllCategory()
        {
            return this._dbContext.Category.ToList();
        }

        public Category getCategoryById(int id)
        {
            var category = this._dbContext.Category.Find(id);
            return category;
        }

        public string RemoveCategory(int id)
        {
            try
            {
                var categoryToRemove = this.getCategoryById(id);
                this._dbContext.Category.Remove(categoryToRemove);
                this._dbContext.SaveChanges();
                return "Category removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateCategory(int id, Category cat)
        {
            try
            {
                var categoryUpdate = this._dbContext.Category.Find(id);
                if (categoryUpdate != null)
                {
                    categoryUpdate.designation = cat.designation;
                    categoryUpdate.description = cat.description;
                    categoryUpdate.price = cat.price;

                    this._dbContext.Category.Update(categoryUpdate);
                    this._dbContext.SaveChanges();
                    return "category update successfully";
                }
                else
                {
                    return "Aucune cathegory trouver";
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
