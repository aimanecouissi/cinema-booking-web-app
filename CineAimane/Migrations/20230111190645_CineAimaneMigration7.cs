using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration7 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "6d14a302-1128-42a4-976a-40ee85045c75");

			migrationBuilder.DropColumn(
				name: "Showtimes",
				table: "Movies");

			migrationBuilder.CreateTable(
				name: "Showtime",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
					MovieId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Showtime", x => x.Id);
					table.ForeignKey(
						name: "FK_Showtime_Movies_MovieId",
						column: x => x.MovieId,
						principalTable: "Movies",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "f3885486-973a-419e-ab9e-29ca07d87b5a", 0, "499c85e4-b0a8-4cc1-9317-65d327e8fd76", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEG+Jzrt1p5dvd2ac01TrnInLqM3X6eGBMsLVHZ4mNNHa7HkKH5pBiARiCXBqOQWx4A==", null, false, "c3f8114c-417b-4b08-a7b3-d69566a2395b", false, "aimanecouissi" });

			migrationBuilder.CreateIndex(
				name: "IX_Showtime_MovieId",
				table: "Showtime",
				column: "MovieId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Showtime");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "f3885486-973a-419e-ab9e-29ca07d87b5a");

			migrationBuilder.AddColumn<string>(
				name: "Showtimes",
				table: "Movies",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "6d14a302-1128-42a4-976a-40ee85045c75", 0, "ad4e2481-8b75-427d-9505-9832feb96e1b", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEHuS49jnIgx+mWtb6tSltKPgObQ7CESdhnzY2cDnJqMgMtTnIi2KoHTTSTia7aDHrg==", null, false, "b683c24e-5e04-4958-ad53-4b764332e0eb", false, "aimanecouissi" });
		}
	}
}
