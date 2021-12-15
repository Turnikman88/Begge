using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Begge.Data.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ProfilePictures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ProfilePictures",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Beggers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Beggers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Beggers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beggers_RoleId",
                table: "Beggers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beggers_Role_RoleId",
                table: "Beggers",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beggers_Role_RoleId",
                table: "Beggers");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Beggers_RoleId",
                table: "Beggers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ProfilePictures");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ProfilePictures");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Beggers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Beggers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Beggers");
        }
    }
}
