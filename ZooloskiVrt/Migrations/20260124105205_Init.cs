using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooloskiVrt.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentNastambe_Nastambe_NastambaID",
                table: "IncidentNastambe");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentZivotinje_Zivotinje_ZivotinjaID",
                table: "IncidentZivotinje");

            migrationBuilder.DropForeignKey(
                name: "FK_Obaveze_Nastambe_NastambaID",
                table: "Obaveze");

            migrationBuilder.DropForeignKey(
                name: "FK_Obaveze_Radnici_RadnikID",
                table: "Obaveze");

            migrationBuilder.DropForeignKey(
                name: "FK_Posjetitelji_Radnici_VodicID",
                table: "Posjetitelji");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanacije_Incidenti_IncidentID",
                table: "Sanacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanacije_Radnici_RadnikID",
                table: "Sanacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Zivotinje_Nastambe_NastambaID",
                table: "Zivotinje");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentNastambe_Nastambe_NastambaID",
                table: "IncidentNastambe",
                column: "NastambaID",
                principalTable: "Nastambe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentZivotinje_Zivotinje_ZivotinjaID",
                table: "IncidentZivotinje",
                column: "ZivotinjaID",
                principalTable: "Zivotinje",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Obaveze_Nastambe_NastambaID",
                table: "Obaveze",
                column: "NastambaID",
                principalTable: "Nastambe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Obaveze_Radnici_RadnikID",
                table: "Obaveze",
                column: "RadnikID",
                principalTable: "Radnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posjetitelji_Radnici_VodicID",
                table: "Posjetitelji",
                column: "VodicID",
                principalTable: "Radnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanacije_Incidenti_IncidentID",
                table: "Sanacije",
                column: "IncidentID",
                principalTable: "Incidenti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanacije_Radnici_RadnikID",
                table: "Sanacije",
                column: "RadnikID",
                principalTable: "Radnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zivotinje_Nastambe_NastambaID",
                table: "Zivotinje",
                column: "NastambaID",
                principalTable: "Nastambe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentNastambe_Nastambe_NastambaID",
                table: "IncidentNastambe");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentZivotinje_Zivotinje_ZivotinjaID",
                table: "IncidentZivotinje");

            migrationBuilder.DropForeignKey(
                name: "FK_Obaveze_Nastambe_NastambaID",
                table: "Obaveze");

            migrationBuilder.DropForeignKey(
                name: "FK_Obaveze_Radnici_RadnikID",
                table: "Obaveze");

            migrationBuilder.DropForeignKey(
                name: "FK_Posjetitelji_Radnici_VodicID",
                table: "Posjetitelji");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanacije_Incidenti_IncidentID",
                table: "Sanacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanacije_Radnici_RadnikID",
                table: "Sanacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Zivotinje_Nastambe_NastambaID",
                table: "Zivotinje");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentNastambe_Nastambe_NastambaID",
                table: "IncidentNastambe",
                column: "NastambaID",
                principalTable: "Nastambe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentZivotinje_Zivotinje_ZivotinjaID",
                table: "IncidentZivotinje",
                column: "ZivotinjaID",
                principalTable: "Zivotinje",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obaveze_Nastambe_NastambaID",
                table: "Obaveze",
                column: "NastambaID",
                principalTable: "Nastambe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obaveze_Radnici_RadnikID",
                table: "Obaveze",
                column: "RadnikID",
                principalTable: "Radnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posjetitelji_Radnici_VodicID",
                table: "Posjetitelji",
                column: "VodicID",
                principalTable: "Radnici",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanacije_Incidenti_IncidentID",
                table: "Sanacije",
                column: "IncidentID",
                principalTable: "Incidenti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanacije_Radnici_RadnikID",
                table: "Sanacije",
                column: "RadnikID",
                principalTable: "Radnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zivotinje_Nastambe_NastambaID",
                table: "Zivotinje",
                column: "NastambaID",
                principalTable: "Nastambe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
