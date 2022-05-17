using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace ApiHotel.Controllers
{
    [Produces("application/json")]
    [Route("api/ClasseComptes")]
    public class ClasseCompteController : Controller
    {
        private readonly IClasseCompte _classecompte;

        public ClasseCompteController(IClasseCompte classecompte)
        {
            _classecompte = classecompte;
        }

        //GET api/classecomptes
        [HttpGet]
        public List<ClasseCompte> Get()
        {
            return _classecompte.GetAllClasseCompte();
        }

        //GET api/classecomptes/50
        [HttpGet("{id}")]
        public ClasseCompte Get(int id)
        {
            return _classecompte.GetClasseCompteById(id);
        }

        //POST api/classecomptes
        [HttpPost]
        public String Post([FromBody]ClasseCompte classecompte)
        {
            return this._classecompte.PostClasseCompte(classecompte);
        }

        //PUT api/classecomptes/50
        [HttpPut("{id}")]
        public String Put(int id, [FromBody]ClasseCompte classecompte)
        {
            return this._classecompte.PutClasseCompte(id, classecompte);
        }

        //DELETE api/classecomptes/50
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._classecompte.DeleteClasseCompte(id);
        }
    }
}
