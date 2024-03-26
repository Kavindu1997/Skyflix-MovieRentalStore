using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyFlix.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMembershipTypesWithName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name='Pay as You Go' WHERE Id=1");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE Id=2");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name='Quarterly' WHERE Id=3");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name='Annual' WHERE Id=4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
