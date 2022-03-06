using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Model
{
    public class Reservation
    {
        [Key]
        public int id { get; set; }
        public Client client { get; set; }
        public Room room { get; set; }
        public DateTime dateReservation { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public int NbrPerson { get; set; }

    }
}
