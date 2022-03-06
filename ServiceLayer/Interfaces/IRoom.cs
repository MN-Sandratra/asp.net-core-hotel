using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IRoom
    {
        //get People
        List<Room> getRoom();

        //get Person by id
        Room getRoomById(int id);

        //Add
        String AddRoom(Room room);
        //update
        String UpdateRoom(int id, Room room);
        //delete
        String RemoveRoom(int id);
    }
}
