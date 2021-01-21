using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCrud.Data.Migrations
{
    public partial class Version0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    Site = table.Column<string>(maxLength: 255, nullable: true),
                    QuantidadeFuncionarios = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.InsertData(table: "Empresas",
                columns: new[] { "Id", "Nome", "QuantidadeFuncionarios", "Site" },
                values: new object[] { 1L, "Apple", 2, "www.apple.com" });

            migrationBuilder.InsertData(table: "Empresas",
                columns: new[] { "Id", "Nome", "QuantidadeFuncionarios", "Site" },
                values: new object[] { 2L, "Google", 55, "www.google.com" });

            migrationBuilder.InsertData(table: "Empresas",
                columns: new[] { "Id", "Nome", "QuantidadeFuncionarios", "Site" },
                values: new object[] { 3L, "Microsoft", 120, "www.microsoft.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Empresas");
        }
    }
}