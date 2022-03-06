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
    [Route("api/Rooms")]
    public class RoomController : Controller
    {
        private readonly IRoom _room;

        public RoomController(IRoom room)
        {
            _room = room;
        }

        // GET api/rooms
        [HttpGet]
        public List<Room> Get()
        {
            return _room.getRoom();
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public Room Get(int id)
        {
            return _room.getRoomById(id);
        }
        // POST api/values
        [HttpPost]
        public String Post([FromBody]Room room)
        {
            return this._room.AddRoom(room);
        }

        // PUT api/persons/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Room room)
        {
            return this._room.UpdateRoom(id, room);
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._room.RemoveRoom(id);
        }
    }
}