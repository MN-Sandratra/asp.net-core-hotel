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
    [Route("api/Reservations")]
    public class ReservationController : Controller
    {
        private readonly IReservation _reservation;

        public ReservationController(IReservation reservation)
        {
            _reservation = reservation;
        }

        // GET api/reservations
        [HttpGet]
        public List<Reservation> Get()
        {
            return _reservation.getAllReservation();
        }

        // GET api/reservations/5
        [HttpGet("{id}")]
        public Reservation Get(int id)
        {
            return _reservation.getReservationById(id);
        }
        // POST api/reservtions
        [HttpPost]
        public String Post([FromBody]Reservation reserv)
        {
            return this._reservation.AddReservation(reserv);
        }

        // PUT api/reservations/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Reservation reserv)
        {
            return this._reservation.UpdateReservation(id, reserv);
        }

        // DELETE api/reservations/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._reservation.RemoveReservation(id);
        }
    }
}