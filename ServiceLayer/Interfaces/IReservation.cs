using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IReservation
    {
        //get Reservation
        List<Reservation> getAllReservation();

        //get Reservation by id
        Reservation getReservationById(int id);

        //Add
        String AddReservation(Reservation reservation);
        //update
        String UpdateReservation(int id, Reservation Reservation);
        //delete
        String RemoveReservation(int id);
    }
}
