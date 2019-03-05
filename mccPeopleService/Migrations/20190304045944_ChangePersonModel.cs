using Microsoft.EntityFrameworkCore.Migrations;

namespace mccPeopleServiceAPI.Migrations
{
    public partial class ChangePersonModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "People",
                newName: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "People",
                newName: "Nickname");
        }
    }
}
