using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class BranchUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "bce6f913-5c95-4fca-8b5b-9d11024a6f81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJvWFWeiCfRW7qXg2s4ePSwd+H/jYPZt80k52SNxV+VoEwhewz3sbnCPWpraRQK0EA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "c0ce08bd-73d8-42d0-b63e-33ba5dc8ea93");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEAAalD6t1aHFFKyCHQosEIaKLlzqPp/8Qh8r89KmdryRPqAB/Ukui9VRsq7vC89MNw==");
        }
    }
}
