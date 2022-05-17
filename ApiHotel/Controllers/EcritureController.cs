using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace ApiHotel.Controllers
{
    [Produces("application/json")]
    [Route("api/Ecritures")]
    public class EcritureController : Controller
    {
        private readonly IEcriture _ecriture;

        public EcritureController(IEcriture ecriture)
        {
            _ecriture = ecriture;
        }

        //GET api/ecritures
        [HttpGet]
        public List<Ecriture> Get()
        {
            return _ecriture.GetAllEcriture();
        }

        //GET api/ecritures/50
        [HttpGet("{id}")]
        public Ecriture Get(int id)
        {
            return _ecriture.GetEcritureById(id);
        }

        //POST api/ecritures
        [HttpPost]
        public String Post([FromBody]Ecriture ecriture)
        {
            return this._ecriture.PostEcriture(ecriture);
        }

        //PUT api/ecritures/50
        [HttpPut("{id}")]
        public String Put(int id, [FromBody]Ecriture ecriture)
        {
            return this._ecriture.PutEcriture(id, ecriture);
        }

        //DELETE api/ecritures/50
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._ecriture.DeleteEcriture(id);
        }
    }
}
