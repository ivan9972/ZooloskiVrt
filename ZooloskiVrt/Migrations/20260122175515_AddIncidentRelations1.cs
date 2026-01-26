using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooloskiVrt.Migrations
{
    /// <inheritdoc />
    public partial class AddIncidentRelations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentNastamba_Incidenti_IncidentID",
                table: "IncidentNastamba");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentNastamba_Nastambe_NastambaID",
                table: "IncidentNastamba");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentZivotinja_Incidenti_IncidentID",
                table: "IncidentZivotinja");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentZivotinja_Zivotinje_ZivotinjaID",
                table: "IncidentZivotinja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentZivotinja",
                table: "IncidentZivotinja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentNastamba",
                table: "IncidentNastamba");

            migrationBuilder.RenameTable(
                name: "IncidentZivotinja",
                newName: "IncidentZivotinje");

            migrationBuilder.RenameTable(
                name: "IncidentNastamba",
                newName: "IncidentNastambe");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentZivotinja_ZivotinjaID",
                table: "IncidentZivotinje",
                newName: "IX_IncidentZivotinje_ZivotinjaID");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentZivotinja_IncidentID",
                table: "IncidentZivotinje",
                newName: "IX_IncidentZivotinje_IncidentID");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentNastamba_NastambaID",
                table: "IncidentNastambe",
                newName: "IX_IncidentNastambe_NastambaID");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentNastamba_IncidentID",
                table: "IncidentNastambe",
                newName: "IX_IncidentNastambe_IncidentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentZivotinje",
                table: "IncidentZivotinje",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentNastambe",
                table: "IncidentNastambe",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentNastambe_Incidenti_IncidentID",
                table: "IncidentNastambe",
                column: "IncidentID",
                principalTable: "Incidenti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentNastambe_Nastambe_NastambaID",
                table: "IncidentNastambe",
                column: "NastambaID",
                principalTable: "Nastambe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentZivotinje_Incidenti_IncidentID",
                table: "IncidentZivotinje",
                column: "IncidentID",
                principalTable: "Incidenti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentZivotinje_Zivotinje_ZivotinjaID",
                table: "IncidentZivotinje",
                column: "ZivotinjaID",
                principalTable: "Zivotinje",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentNastambe_Incidenti_IncidentID",
                table: "IncidentNastambe");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentNastambe_Nastambe_NastambaID",
                table: "IncidentNastambe");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentZivotinje_Incidenti_IncidentID",
                table: "IncidentZivotinje");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentZivotinje_Zivotinje_ZivotinjaID",
                table: "IncidentZivotinje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentZivotinje",
                table: "IncidentZivotinje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentNastambe",
                table: "IncidentNastambe");

            migrationBuilder.RenameTable(
                name: "IncidentZivotinje",
                newName: "IncidentZivotinja");

            migrationBuilder.RenameTable(
                name: "IncidentNastambe",
                newName: "IncidentNastamba");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentZivotinje_ZivotinjaID",
                table: "IncidentZivotinja",
                newName: "IX_IncidentZivotinja_ZivotinjaID");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentZivotinje_IncidentID",
                table: "IncidentZivotinja",
                newName: "IX_IncidentZivotinja_IncidentID");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentNastambe_NastambaID",
                table: "IncidentNastamba",
                newName: "IX_IncidentNastamba_NastambaID");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentNastambe_IncidentID",
                table: "IncidentNastamba",
                newName: "IX_IncidentNastamba_IncidentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentZivotinja",
                table: "IncidentZivotinja",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentNastamba",
                table: "IncidentNastamba",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentNastamba_Incidenti_IncidentID",
                table: "IncidentNastamba",
                column: "IncidentID",
                principalTable: "Incidenti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentNastamba_Nastambe_NastambaID",
                table: "IncidentNastamba",
                column: "NastambaID",
                principalTable: "Nastambe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentZivotinja_Incidenti_IncidentID",
                table: "IncidentZivotinja",
                column: "IncidentID",
                principalTable: "Incidenti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentZivotinja_Zivotinje_ZivotinjaID",
                table: "IncidentZivotinja",
                column: "ZivotinjaID",
                principalTable: "Zivotinje",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
