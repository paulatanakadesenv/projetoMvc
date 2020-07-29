using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasWebMvc.Migrations
{
    public partial class OutrasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatatNascimento",
                table: "Vendedor",
                newName: "DataNascimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Vendedor",
                newName: "DatatNascimento");
        }
    }
}
