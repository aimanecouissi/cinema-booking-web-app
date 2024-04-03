using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration10 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
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

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "AspNetUserTokens",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(128)",
				oldMaxLength: 128);

			migrationBuilder.AlterColumn<string>(
				name: "LoginProvider",
				table: "AspNetUserTokens",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(128)",
				oldMaxLength: 128);

			migrationBuilder.AlterColumn<string>(
				name: "ProviderKey",
				table: "AspNetUserLogins",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(128)",
				oldMaxLength: 128);

			migrationBuilder.AlterColumn<string>(
				name: "LoginProvider",
				table: "AspNetUserLogins",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(128)",
				oldMaxLength: 128);

			migrationBuilder.CreateTable(
				name: "Showdates",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Date = table.Column<DateTime>(type: "datetime2", nullable: false),
					Reserved = table.Column<int>(type: "int", nullable: false),
					ShowtimeId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Showdates", x => x.Id);
					table.ForeignKey(
						name: "FK_Showdates_Showtimes_ShowtimeId",
						column: x => x.ShowtimeId,
						principalTable: "Showtimes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[] { "6bb00a43-a4e5-4245-830b-1ffe68d02354", "be980a42-200b-44c3-8d8f-3056d4cc78c2", "Admin", "ADMIN" });

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "a86dd582-ec26-40c4-bec4-8954d3396bc0", 0, "491a71b4-a317-4ff4-a2be-a2c165a1a07b", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEJNO8aCX24w4lh7odI+H4aQqsjhP6iHGzajYs9xWEYIdUAEGDmZl9MyqzkKsY8ktaw==", null, false, "16896eeb-2517-403b-9369-e32815c911f3", false, "aimanecouissi" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "6bb00a43-a4e5-4245-830b-1ffe68d02354", "a86dd582-ec26-40c4-bec4-8954d3396bc0" });

			migrationBuilder.CreateIndex(
				name: "IX_Showdates_ShowtimeId",
				table: "Showdates",
				column: "ShowtimeId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Showdates");

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "6bb00a43-a4e5-4245-830b-1ffe68d02354", "a86dd582-ec26-40c4-bec4-8954d3396bc0" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "6bb00a43-a4e5-4245-830b-1ffe68d02354");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "a86dd582-ec26-40c4-bec4-8954d3396bc0");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "AspNetUserTokens",
				type: "nvarchar(128)",
				maxLength: 128,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");

			migrationBuilder.AlterColumn<string>(
				name: "LoginProvider",
				table: "AspNetUserTokens",
				type: "nvarchar(128)",
				maxLength: 128,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");

			migrationBuilder.AlterColumn<string>(
				name: "ProviderKey",
				table: "AspNetUserLogins",
				type: "nvarchar(128)",
				maxLength: 128,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");

			migrationBuilder.AlterColumn<string>(
				name: "LoginProvider",
				table: "AspNetUserLogins",
				type: "nvarchar(128)",
				maxLength: 128,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");

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
	}
}
