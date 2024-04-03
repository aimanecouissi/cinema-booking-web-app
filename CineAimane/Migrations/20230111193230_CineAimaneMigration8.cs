using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration8 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Showtime_Movies_MovieId",
				table: "Showtime");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Showtime",
				table: "Showtime");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "f3885486-973a-419e-ab9e-29ca07d87b5a");

			migrationBuilder.RenameTable(
				name: "Showtime",
				newName: "Showtimes");

			migrationBuilder.RenameIndex(
				name: "IX_Showtime_MovieId",
				table: "Showtimes",
				newName: "IX_Showtimes_MovieId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Showtimes",
				table: "Showtimes",
				column: "Id");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "2b85d471-35bb-47f3-a793-bc8e95f70f31", 0, "5575d7f5-d3ab-4773-a056-11b35548a88f", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEGZOwqJ2g8um9lflFcRmMQ80xuXVRxp7enDbLgCQ2FqOtrcD0fj124ssKm3kOJAJrw==", null, false, "5cf4cb8a-3aac-4f93-94ad-c08728ca0787", false, "aimanecouissi" });

			migrationBuilder.AddForeignKey(
				name: "FK_Showtimes_Movies_MovieId",
				table: "Showtimes",
				column: "MovieId",
				principalTable: "Movies",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Showtimes_Movies_MovieId",
				table: "Showtimes");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Showtimes",
				table: "Showtimes");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "2b85d471-35bb-47f3-a793-bc8e95f70f31");

			migrationBuilder.RenameTable(
				name: "Showtimes",
				newName: "Showtime");

			migrationBuilder.RenameIndex(
				name: "IX_Showtimes_MovieId",
				table: "Showtime",
				newName: "IX_Showtime_MovieId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Showtime",
				table: "Showtime",
				column: "Id");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "f3885486-973a-419e-ab9e-29ca07d87b5a", 0, "499c85e4-b0a8-4cc1-9317-65d327e8fd76", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEG+Jzrt1p5dvd2ac01TrnInLqM3X6eGBMsLVHZ4mNNHa7HkKH5pBiARiCXBqOQWx4A==", null, false, "c3f8114c-417b-4b08-a7b3-d69566a2395b", false, "aimanecouissi" });

			migrationBuilder.AddForeignKey(
				name: "FK_Showtime_Movies_MovieId",
				table: "Showtime",
				column: "MovieId",
				principalTable: "Movies",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
