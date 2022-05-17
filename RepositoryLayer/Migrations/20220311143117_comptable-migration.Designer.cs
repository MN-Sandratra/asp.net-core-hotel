﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RepositoryLayer;
using System;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(BDDContext))]
    [Migration("20220311143117_comptable-migration")]
    partial class comptablemigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("DomainLayer.Model.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("designation");

                    b.Property<double>("price");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("DomainLayer.Model.ClasseCompte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nomClasse");

                    b.Property<int>("numeroClasse");

                    b.HasKey("Id");

                    b.ToTable("ClasseComptes");
                });

            modelBuilder.Entity("DomainLayer.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("personid");

                    b.HasKey("Id");

                    b.HasIndex("personid");

                    b.ToTable("client");
                });

            modelBuilder.Entity("DomainLayer.Model.Compte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("classecompteId");

                    b.Property<string>("intituleCompte");

                    b.Property<int>("numeroCompte");

                    b.Property<int>("typecompteId");

                    b.HasKey("Id");

                    b.HasIndex("classecompteId");

                    b.HasIndex("typecompteId");

                    b.ToTable("Comptes");
                });

            modelBuilder.Entity("DomainLayer.Model.Ecriture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("dateEcriture");

                    b.Property<string>("libelleEcriture");

                    b.HasKey("Id");

                    b.ToTable("Ecritures");
                });

            modelBuilder.Entity("DomainLayer.Model.Mouvement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("compteId");

                    b.Property<double>("credit");

                    b.Property<double>("debit");

                    b.Property<int>("ecritureId");

                    b.HasKey("Id");

                    b.HasIndex("compteId");

                    b.HasIndex("ecritureId");

                    b.ToTable("Mouvements");
                });

            modelBuilder.Entity("DomainLayer.Model.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CIN");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<string>("phone");

                    b.HasKey("id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DomainLayer.Model.Reservation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NbrPerson");

                    b.Property<int?>("clientId");

                    b.Property<DateTime>("dateDebut");

                    b.Property<DateTime>("dateFin");

                    b.Property<DateTime>("dateReservation");

                    b.Property<int?>("roomnumber");

                    b.HasKey("id");

                    b.HasIndex("clientId");

                    b.HasIndex("roomnumber");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("DomainLayer.Model.Room", b =>
                {
                    b.Property<int>("number")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("categoryid");

                    b.Property<double>("price");

                    b.Property<string>("type");

                    b.HasKey("number");

                    b.HasIndex("categoryid");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("DomainLayer.Model.TypeCompte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nomTypeCompte");

                    b.HasKey("Id");

                    b.ToTable("TypeComptes");
                });

            modelBuilder.Entity("DomainLayer.Model.Client", b =>
                {
                    b.HasOne("DomainLayer.Model.Person", "person")
                        .WithMany()
                        .HasForeignKey("personid");
                });

            modelBuilder.Entity("DomainLayer.Model.Compte", b =>
                {
                    b.HasOne("DomainLayer.Model.ClasseCompte", "classecompte")
                        .WithMany()
                        .HasForeignKey("classecompteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainLayer.Model.TypeCompte", "typecompte")
                        .WithMany()
                        .HasForeignKey("typecompteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainLayer.Model.Mouvement", b =>
                {
                    b.HasOne("DomainLayer.Model.Compte", "compte")
                        .WithMany()
                        .HasForeignKey("compteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainLayer.Model.Ecriture", "ecriture")
                        .WithMany()
                        .HasForeignKey("ecritureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainLayer.Model.Reservation", b =>
                {
                    b.HasOne("DomainLayer.Model.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientId");

                    b.HasOne("DomainLayer.Model.Room", "room")
                        .WithMany()
                        .HasForeignKey("roomnumber");
                });

            modelBuilder.Entity("DomainLayer.Model.Room", b =>
                {
                    b.HasOne("DomainLayer.Model.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryid");
                });
#pragma warning restore 612, 618
        }
    }
}
