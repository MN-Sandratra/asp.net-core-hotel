using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace ApiHotel.Controllers
{
    [Produces("application/json")]
    [Route("api/Mouvements")]
    public class MouvementController : Controller
    {
        private readonly IMouvement _mouvement;

        public MouvementController(IMouvement mouvement)
        {
            _mouvement = mouvement;
        }

        //GET api/mouvements
        [HttpGet]
        public List<Mouvement> Get()
        {
            return _mouvement.GetAllMouvement();
        }

        //GET api/mouvements/50
        [HttpGet("{id}")]
        public Mouvement Get(int id)
        {
            return _mouvement.GetMouvementById(id);
        }

        //GET api/mouvements/compte-mouvement
        [HttpGet("compte-mouvement")]
        public IActionResult GetCompteMouvement()
        {
            return Ok(_mouvement.Select1apls());
        }

        //POST api/mouvements
        [HttpPost]
        public String Post([FromBody]Mouvement mouvement)
        {
            return this._mouvement.PostMouvement(mouvement);
        }

        //PUT api/mouvements/50
        [HttpPut("{id}")]
        public String Put(int id, [FromBody]Mouvement mouvement)
        {
            return this._mouvement.PutMouvement(id, mouvement);
        }

        //DELETE api/mouvements/50
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._mouvement.DeleteMouvement(id);
        }
    }
}
