using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public class BDDContext:DbContext
    {
        #region Entity
        public DbSet<Person> People { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> client { get; set; }
        #endregion

        public BDDContext(DbContextOptions con) : base(con)
        {

        }
    }
}
