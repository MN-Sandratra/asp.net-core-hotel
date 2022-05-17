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
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<TypeCompte> TypeComptes { get; set; }
        public DbSet<ClasseCompte> ClasseComptes { get; set; }
        public DbSet<Ecriture> Ecritures { get; set; }
        public DbSet<Mouvement> Mouvements { get; set; }
        #endregion

        public BDDContext(DbContextOptions con) : base(con) { }

        
}
}
