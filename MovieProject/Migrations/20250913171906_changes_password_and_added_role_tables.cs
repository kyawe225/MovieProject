using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieProject.Migrations
{
    /// <inheritdoc />
    public partial class changes_password_and_added_role_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "tbl_users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tbl_users",
                newName: "PasswordSalt");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "tbl_users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tbl_roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    Description = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_RoleId",
                table: "tbl_users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_users_tbl_roles_RoleId",
                table: "tbl_users",
                column: "RoleId",
                principalTable: "tbl_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_users_tbl_roles_RoleId",
                table: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_roles");

            migrationBuilder.DropIndex(
                name: "IX_tbl_users_RoleId",
                table: "tbl_users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "tbl_users");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "tbl_users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "tbl_users",
                newName: "Password");
        }
    }
}
