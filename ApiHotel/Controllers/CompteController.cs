using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace ApiHotel.Controllers
{
    [Produces("application/json")]
    [Route("api/Comptes")]
    public class CompteController : Controller
    {
        private readonly ICompte _compte;

        public CompteController(ICompte compte)
        {
            _compte = compte;
        }

        //GET api/comptes
        [HttpGet]
        public List<Compte> Get()
        {
            return _compte.GetAllCompte();
        }

        //GET api/comptes/50
        [HttpGet("{id}")]
        public Compte Get(int id)
        {
            return _compte.GetCompteById(id);
        }

        //POST api/comptes
        [HttpPost]
        public String Post([FromBody]Compte compte)
        {
            return this._compte.PostCompte(compte);
        }

        //PUT api/comptes/50
        [HttpPut("{id}")]
        public String Put(int id, [FromBody]Compte compte)
        {
            return this._compte.PutCompte(id, compte);
        }

        //DELETE api/comptes/50
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._compte.DeleteCompte(id);
        }
    }
}
