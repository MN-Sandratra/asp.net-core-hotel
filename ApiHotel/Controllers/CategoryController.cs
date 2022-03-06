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
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        // GET api/category
        [HttpGet]
        public List<Category> Get()
        {
            return _category.getAllCategory();
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _category.getCategoryById(id);
        }
        // POST api/category
        [HttpPost]
        public String Post([FromBody]Category cat)
        {
            return this._category.AddCategory(cat);
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Category cat)
        {
            return this._category.UpdateCategory(id, cat);
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._category.RemoveCategory(id);
        }
    }
}