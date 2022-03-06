using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class ReservationService : IReservation
    {
        private readonly BDDContext _dbContext;
        public ReservationService(BDDContext bddContext)
        {
            _dbContext = bddContext;
        }
        public string AddReservation(Reservation reservation)
        {
            try
            {
                this._dbContext.Reservations.Add(reservation);
                this._dbContext.SaveChanges();
                return "Reservation add successfully";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public List<Reservation> getAllReservation()
        {
            return _dbContext.Reservations.ToList();
        }

        public Reservation getReservationById(int id)
        {
            var reservtion = this._dbContext.Reservations.Find(id);
            return reservtion;
        }

        public string RemoveReservation(int id)
        {
            try
            {
                var ReservationToRemove = this.getReservationById(id);
                this._dbContext.Reservations.Remove(ReservationToRemove);
                this._dbContext.SaveChanges();
                return "Reservation removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateReservation(int id, Reservation Reservation)
        {
            try
            {
                var reservationUpdate = this._dbContext.Reservations.Find(id);
                if (reservationUpdate != null)
                {
                    reservationUpdate.client = Reservation.client;
                    reservationUpdate.dateDebut = Reservation.dateDebut;
                    reservationUpdate.dateFin = Reservation.dateFin;
                    reservationUpdate.room = Reservation.room;
                    reservationUpdate.dateReservation = Reservation.dateReservation;
                    
                    this._dbContext.SaveChanges();
                    return "room update successfully";
                }
                else
                {
                    return "Aucune Reservation trouver";
                }
            }
            catch ( Exception e)
            {

                return e.Message;
            }
        }
    }
}
