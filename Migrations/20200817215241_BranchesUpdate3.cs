using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class BranchesUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_AspNetUsers_LiderId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Branch_LiderId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "LiderId",
                table: "Branch");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Branch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LiderId",
                table: "Branch",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Branch_LiderId",
                table: "Branch",
                column: "LiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_AspNetUsers_LiderId",
                table: "Branch",
                column: "LiderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
