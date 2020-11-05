using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class InvoiceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "5641c7dc-54f5-46a0-a85d-e3db9569ea7a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPZe3IlGrNtHj5YgTc3foRrFjuqbTsTTqoo+lT3Vz40asgozfTUhFqn+jN2ea4y+Og==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "074825bb-a252-47c3-879d-bdf86d15e230");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHpRC7k3yfYotP42QQ0C1mM4tlNFvdNi1BMgZOIg0Eo0Tv5JLE2v1y4fIGsWjbG5IA==");
        }
    }
}
