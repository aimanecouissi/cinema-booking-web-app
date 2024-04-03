using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration9 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "2b85d471-35bb-47f3-a793-bc8e95f70f31");

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[] { "5a438b9d-4643-4254-be5e-6d90c6f3f0c7", "990fab35-f149-4c81-9037-28262e1f07ba", "Admin", "ADMIN" });

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "01e06dd5-0e1d-414c-89b7-56450d0df8b6", 0, "f497eda4-2c52-4b4d-9c98-01f70241c85f", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEDQeXhosTsFtDwZodNFvEDK/yEfzWmp7nlwaOPqZ2++JOK6wRo4jCSSNBretMBmrLA==", null, false, "7acce675-47c0-4abe-becd-fefb870f354d", false, "aimanecouissi" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "5a438b9d-4643-4254-be5e-6d90c6f3f0c7", "01e06dd5-0e1d-414c-89b7-56450d0df8b6" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "5a438b9d-4643-4254-be5e-6d90c6f3f0c7", "01e06dd5-0e1d-414c-89b7-56450d0df8b6" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "5a438b9d-4643-4254-be5e-6d90c6f3f0c7");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "01e06dd5-0e1d-414c-89b7-56450d0df8b6");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "2b85d471-35bb-47f3-a793-bc8e95f70f31", 0, "5575d7f5-d3ab-4773-a056-11b35548a88f", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEGZOwqJ2g8um9lflFcRmMQ80xuXVRxp7enDbLgCQ2FqOtrcD0fj124ssKm3kOJAJrw==", null, false, "5cf4cb8a-3aac-4f93-94ad-c08728ca0787", false, "aimanecouissi" });
		}
	}
}
