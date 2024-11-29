using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crow.Migrations
{
    /// <inheritdoc />
    public partial class V2_tabela_cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "tabela_cliente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "tabela_cliente");
        }
    }
}
