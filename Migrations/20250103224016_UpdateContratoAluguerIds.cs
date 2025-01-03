using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_JAP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContratoAluguerIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Km",
                table: "ContratosAluguer",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Km",
                table: "ContratosAluguer",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
