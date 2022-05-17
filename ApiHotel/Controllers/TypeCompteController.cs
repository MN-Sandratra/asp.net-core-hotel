using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace ApiHotel.Controllers
{
    [Produces("application/json")]
    [Route("api/TypeComptes")]
    public class TypeCompteController : Controller
    {
        private readonly ITypeCompte _typecompte;

        public TypeCompteController(ITypeCompte typecompte)
        {
            _typecompte = typecompte;
        }

        //GET api/typecomptes
        [HttpGet]
        public List<TypeCompte> Get()
        {
            return _typecompte.GetAllTypeCompte();
        }

        //GET api/typecomptes/50
        [HttpGet("{id}")]
        public TypeCompte Get(int id)
        {
            return _typecompte.GetTypeCompteById(id);
        }

        //POST api/typecomptes
        [HttpPost]
        public String Post([FromBody]TypeCompte typecompte)
        {
            return this._typecompte.PostTypeCompte(typecompte);
        }

        //PUT api/typecomptes/50
        [HttpPut("{id}")]
        public String Put(int id, [FromBody]TypeCompte typecompte)
        {
            return this._typecompte.PutTypeCompte(id, typecompte);
        }

        //DELETE api/typecomptes/50
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._typecompte.DeleteTypeCompte(id);
        }
    }
}
