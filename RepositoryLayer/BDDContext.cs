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
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderLine> OrderLines{ get; set; }
        public DbSet<Input> Inputs{ get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Reception> Receptions { get; set; }

        public BDDContext(DbContextOptions con) : base(con)
        {

        }
    }
}
