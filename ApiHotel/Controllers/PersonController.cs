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
    [Route("api/Persons")]
    public class PersonController : Controller
    {
        private readonly IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }

        // GET api/persons
        [HttpGet]
        public List<Person> Get()
        {
            return _person.getPeople();
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _person.getPersonById(id);
        }
        // POST api/values
        [HttpPost]
        public String Post([FromBody]Person pers)
        {
            return this._person.AddPerson(pers);
        }

        // PUT api/persons/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Person pers)
        {
            return this._person.UpdatePerson(id,pers);
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._person.RemovePerson(id);
        }
    }
}