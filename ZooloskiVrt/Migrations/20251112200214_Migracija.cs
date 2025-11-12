using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooloskiVrt.Migrations
{
    /// <inheritdoc />
    public partial class Migracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ozbiljnost = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidenti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nastambe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazinaOsuncanosti = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nastambe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Radnici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obrazovanje = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IncidentNastamba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentID = table.Column<int>(type: "int", nullable: false),
                    NastambaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentNastamba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IncidentNastamba_Incidenti_IncidentID",
                        column: x => x.IncidentID,
                        principalTable: "Incidenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncidentNastamba_Nastambe_NastambaID",
                        column: x => x.NastambaID,
                        principalTable: "Nastambe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zivotinje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatinskiNaziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HrvatskiNaziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NacinNabave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumNabave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aktivna = table.Column<bool>(type: "bit", nullable: false),
                    NastambaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zivotinje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zivotinje_Nastambe_NastambaID",
                        column: x => x.NastambaID,
                        principalTable: "Nastambe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bolovanja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolovanja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bolovanja_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GodisnjiOdmori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GodisnjiOdmori", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GodisnjiOdmori_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licence",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trajna = table.Column<bool>(type: "bit", nullable: false),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licence", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Licence_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obaveze",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadnikID = table.Column<int>(type: "int", nullable: false),
                    NastambaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obaveze", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Obaveze_Nastambe_NastambaID",
                        column: x => x.NastambaID,
                        principalTable: "Nastambe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obaveze_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obuke",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obuke", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Obuke_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posjetitelji",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeGrupe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminPosjete = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VodicID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posjetitelji", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posjetitelji_Radnici_VodicID",
                        column: x => x.VodicID,
                        principalTable: "Radnici",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Sanacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trosak = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncidentID = table.Column<int>(type: "int", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanacije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sanacije_Incidenti_IncidentID",
                        column: x => x.IncidentID,
                        principalTable: "Incidenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sanacije_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smjene",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smjene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Smjene_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidentZivotinja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentID = table.Column<int>(type: "int", nullable: false),
                    ZivotinjaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentZivotinja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IncidentZivotinja_Incidenti_IncidentID",
                        column: x => x.IncidentID,
                        principalTable: "Incidenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncidentZivotinja_Zivotinje_ZivotinjaID",
                        column: x => x.ZivotinjaID,
                        principalTable: "Zivotinje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Troskovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iznos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ZivotinjaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troskovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Troskovi_Zivotinje_ZivotinjaID",
                        column: x => x.ZivotinjaID,
                        principalTable: "Zivotinje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolovanja_RadnikID",
                table: "Bolovanja",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_GodisnjiOdmori_RadnikID",
                table: "GodisnjiOdmori",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentNastamba_IncidentID",
                table: "IncidentNastamba",
                column: "IncidentID");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentNastamba_NastambaID",
                table: "IncidentNastamba",
                column: "NastambaID");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentZivotinja_IncidentID",
                table: "IncidentZivotinja",
                column: "IncidentID");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentZivotinja_ZivotinjaID",
                table: "IncidentZivotinja",
                column: "ZivotinjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Licence_RadnikID",
                table: "Licence",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Obaveze_NastambaID",
                table: "Obaveze",
                column: "NastambaID");

            migrationBuilder.CreateIndex(
                name: "IX_Obaveze_RadnikID",
                table: "Obaveze",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Obuke_RadnikID",
                table: "Obuke",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Posjetitelji_VodicID",
                table: "Posjetitelji",
                column: "VodicID");

            migrationBuilder.CreateIndex(
                name: "IX_Sanacije_IncidentID",
                table: "Sanacije",
                column: "IncidentID");

            migrationBuilder.CreateIndex(
                name: "IX_Sanacije_RadnikID",
                table: "Sanacije",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Smjene_RadnikID",
                table: "Smjene",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Troskovi_ZivotinjaID",
                table: "Troskovi",
                column: "ZivotinjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zivotinje_NastambaID",
                table: "Zivotinje",
                column: "NastambaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bolovanja");

            migrationBuilder.DropTable(
                name: "GodisnjiOdmori");

            migrationBuilder.DropTable(
                name: "IncidentNastamba");

            migrationBuilder.DropTable(
                name: "IncidentZivotinja");

            migrationBuilder.DropTable(
                name: "Licence");

            migrationBuilder.DropTable(
                name: "Obaveze");

            migrationBuilder.DropTable(
                name: "Obuke");

            migrationBuilder.DropTable(
                name: "Posjetitelji");

            migrationBuilder.DropTable(
                name: "Sanacije");

            migrationBuilder.DropTable(
                name: "Smjene");

            migrationBuilder.DropTable(
                name: "Troskovi");

            migrationBuilder.DropTable(
                name: "Incidenti");

            migrationBuilder.DropTable(
                name: "Radnici");

            migrationBuilder.DropTable(
                name: "Zivotinje");

            migrationBuilder.DropTable(
                name: "Nastambe");
        }
    }
}
