using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyFlix.Migrations
{
    /// <inheritdoc />
    public partial class ApplyAnnotationsToCustomerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSubscribedToNewsLetter",
                table: "Customers",
                type: "tinyint(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSubscribedToNewsLetter",
                table: "Customers",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(255)",
                oldMaxLength: 255);
        }
    }
}
