using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration4 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "e7ff2923-415c-431e-a2df-4171c8a4b239");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "87813b75-c5d0-4e19-946d-2a47eb5d6af1", 0, "054b7e52-0c8c-4cf4-85dd-80c03041e326", "aimanecouissi@cineaimane.com", true, false, null, "AIMANECOUISSI@CINEAIMANE.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAED7D9zqCmlujwbQw1jlb3aesw6MPKsgoZ8MbDvyjMBeIIvouIFygrA5s3vo2HQTvzQ==", null, false, "66bf4d80-4d1e-44a7-9328-207f9ffa47fd", false, "aimanecouissi" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "87813b75-c5d0-4e19-946d-2a47eb5d6af1");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "e7ff2923-415c-431e-a2df-4171c8a4b239", 0, "89e392b7-61fe-4b3c-8ef9-8b9c05a4924e", "aimanecouissi@cineaimane.com", true, false, null, "AIMANECOUISSI@CINEAIMANE.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEMm6tSceuHhJcvrpCealv3wmB/UyauyBDnRLwltPHMpwZIp4ErPVJUSpq5A43sSEXA==", null, false, "8dea6f1d-ec92-4fe2-b3db-6a1c5607aa2e", false, "aimanecouissi" });
		}
	}
}
