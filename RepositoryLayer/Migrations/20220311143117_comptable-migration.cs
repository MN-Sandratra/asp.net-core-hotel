using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Migrations
{
    public partial class comptablemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    designation = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ClasseComptes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomClasse = table.Column<string>(nullable: true),
                    numeroClasse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseComptes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ecritures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dateEcriture = table.Column<string>(nullable: true),
                    libelleEcriture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecritures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CIN = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TypeComptes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomTypeCompte = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeComptes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    number = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    categoryid = table.Column<int>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.number);
                    table.ForeignKey(
                        name: "FK_Rooms_Category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    personid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_client_People_personid",
                        column: x => x.personid,
                        principalTable: "People",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comptes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    classecompteId = table.Column<int>(nullable: false),
                    intituleCompte = table.Column<string>(nullable: true),
                    numeroCompte = table.Column<int>(nullable: false),
                    typecompteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comptes_ClasseComptes_classecompteId",
                        column: x => x.classecompteId,
                        principalTable: "ClasseComptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comptes_TypeComptes_typecompteId",
                        column: x => x.typecompteId,
                        principalTable: "TypeComptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NbrPerson = table.Column<int>(nullable: false),
                    clientId = table.Column<int>(nullable: true),
                    dateDebut = table.Column<DateTime>(nullable: false),
                    dateFin = table.Column<DateTime>(nullable: false),
                    dateReservation = table.Column<DateTime>(nullable: false),
                    roomnumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservations_client_clientId",
                        column: x => x.clientId,
                        principalTable: "client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_roomnumber",
                        column: x => x.roomnumber,
                        principalTable: "Rooms",
                        principalColumn: "number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mouvements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    compteId = table.Column<int>(nullable: false),
                    credit = table.Column<double>(nullable: false),
                    debit = table.Column<double>(nullable: false),
                    ecritureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouvements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mouvements_Comptes_compteId",
                        column: x => x.compteId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mouvements_Ecritures_ecritureId",
                        column: x => x.ecritureId,
                        principalTable: "Ecritures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_personid",
                table: "client",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_classecompteId",
                table: "Comptes",
                column: "classecompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_typecompteId",
                table: "Comptes",
                column: "typecompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mouvements_compteId",
                table: "Mouvements",
                column: "compteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mouvements_ecritureId",
                table: "Mouvements",
                column: "ecritureId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_clientId",
                table: "Reservations",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_roomnumber",
                table: "Reservations",
                column: "roomnumber");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_categoryid",
                table: "Rooms",
                column: "categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mouvements");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Comptes");

            migrationBuilder.DropTable(
                name: "Ecritures");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "ClasseComptes");

            migrationBuilder.DropTable(
                name: "TypeComptes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
