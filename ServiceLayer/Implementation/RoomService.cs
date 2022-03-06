using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class RoomService : IRoom
    {
        private readonly BDDContext _dbContext;
        public RoomService(BDDContext db)
        {
            _dbContext = db;
        }
        public string AddRoom(Room room)
        {
            try
            {
                this._dbContext.Rooms.Add(room);
                this._dbContext.SaveChanges();
                return "Room add successfuly";
            }catch(Exception e)
            {
                return e.Message;
            }
        }

        public List<Room> getRoom()
        {
            return _dbContext.Rooms.ToList();
        }

        public Room getRoomById(int id)
        {
            var roomUpdate = _dbContext.Rooms.Find(id);
            return roomUpdate;
        }

        public string RemoveRoom(int id)
        {
            try
            {
                var roomToDelete = this.getRoomById(id);
                _dbContext.Rooms.Remove(roomToDelete);
                _dbContext.SaveChanges();
                return "Room delete successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdateRoom(int id, Room room)
        {
            try
            {
                var roomUpdate = this._dbContext.Rooms.Find(id);
                if (roomUpdate != null)
                {
                    roomUpdate.type = room.type;
                    roomUpdate.category = room.category;
                    roomUpdate.price = room.price;
                    this._dbContext.Rooms.Update(roomUpdate);
                    this._dbContext.SaveChanges();
                    return "room update successfully";
                }
                else
                {
                    return "Aucune chambre trouver";
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
