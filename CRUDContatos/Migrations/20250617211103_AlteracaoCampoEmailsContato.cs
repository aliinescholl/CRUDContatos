using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDContatos.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoCampoEmailsContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Emails",
                table: "Contato",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emails",
                table: "Contato");
        }
    }
}
