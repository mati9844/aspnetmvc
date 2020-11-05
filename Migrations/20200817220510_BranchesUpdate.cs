using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class BranchesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "a2615a27-8d3d-4abd-b291-771cc08d2014");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGY3VFbmYs2m7HNR8xcJtohpzqowJIlsEhOt/uDRkfZEgO0Ivn8alFA0F0oh3WfncA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "47f1b13c-10f7-4533-afb1-682fcdd5df8d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEMp9S+ryLZyfUYU22nJ7Eb4Kaw+/YKvfzUtfpN7alOY5oyxaVe7cq5H7HSv5nzY0uQ==");
        }
    }
}
