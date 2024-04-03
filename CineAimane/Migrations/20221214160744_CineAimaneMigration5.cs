using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration5 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "87813b75-c5d0-4e19-946d-2a47eb5d6af1");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "74f2e3ea-68d8-48f9-b9a3-5df5683fed98", 0, "6a4247c3-75de-493a-9a43-b96daa4a757f", "aimanecouissi@cineaimane.com", true, false, null, "AIMANECOUISSI@CINEAIMANE.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEC+I53MQDHextJ5R61gfIVVMr+1tYRdGfH98UyKaI3dpmsAFPE6yvXl7zozE9+XuYA==", null, false, "a8dd519c-e980-4c93-8f16-7a98757b2fc1", false, "aimanecouissi" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "74f2e3ea-68d8-48f9-b9a3-5df5683fed98");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "87813b75-c5d0-4e19-946d-2a47eb5d6af1", 0, "054b7e52-0c8c-4cf4-85dd-80c03041e326", "aimanecouissi@cineaimane.com", true, false, null, "AIMANECOUISSI@CINEAIMANE.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAED7D9zqCmlujwbQw1jlb3aesw6MPKsgoZ8MbDvyjMBeIIvouIFygrA5s3vo2HQTvzQ==", null, false, "66bf4d80-4d1e-44a7-9328-207f9ffa47fd", false, "aimanecouissi" });
		}
	}
}
