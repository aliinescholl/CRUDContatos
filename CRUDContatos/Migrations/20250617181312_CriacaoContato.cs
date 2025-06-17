using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDContatos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    TelefonePessoal = table.Column<string>(type: "TEXT", nullable: true),
                    TelefoneComercial = table.Column<string>(type: "TEXT", nullable: true),
                    Empresa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato");
        }
    }
}
