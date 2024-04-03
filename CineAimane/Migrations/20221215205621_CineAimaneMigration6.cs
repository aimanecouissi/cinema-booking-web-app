using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration6 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "74f2e3ea-68d8-48f9-b9a3-5df5683fed98");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "6d14a302-1128-42a4-976a-40ee85045c75", 0, "ad4e2481-8b75-427d-9505-9832feb96e1b", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEHuS49jnIgx+mWtb6tSltKPgObQ7CESdhnzY2cDnJqMgMtTnIi2KoHTTSTia7aDHrg==", null, false, "b683c24e-5e04-4958-ad53-4b764332e0eb", false, "aimanecouissi" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "6d14a302-1128-42a4-976a-40ee85045c75");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "74f2e3ea-68d8-48f9-b9a3-5df5683fed98", 0, "6a4247c3-75de-493a-9a43-b96daa4a757f", "aimanecouissi@cineaimane.com", true, false, null, "AIMANECOUISSI@CINEAIMANE.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEC+I53MQDHextJ5R61gfIVVMr+1tYRdGfH98UyKaI3dpmsAFPE6yvXl7zozE9+XuYA==", null, false, "a8dd519c-e980-4c93-8f16-7a98757b2fc1", false, "aimanecouissi" });
		}
	}
}
