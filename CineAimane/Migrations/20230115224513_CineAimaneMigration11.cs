using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration11 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
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

			migrationBuilder.AddColumn<bool>(
				name: "IsDeleted",
				table: "Showtimes",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[] { "f7b48542-3b55-4876-b400-02f53a3ea90b", "a44f69a0-473c-4ba8-a959-a9173bb77155", "Admin", "ADMIN" });

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "7b3b2784-1880-46ba-8203-ad9ca9ab35a0", 0, "b32acd93-7ea9-438e-8bb3-bacec0b0ef51", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEPbQquNyRDfwju8ddNEg3k2Rc0CqvJGA6bLJkW/W/cwu3vM6U4raOTUPrsplPJpppQ==", null, false, "605d39dd-cb48-4eb0-b281-c9a5002d10d7", false, "aimanecouissi" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "f7b48542-3b55-4876-b400-02f53a3ea90b", "7b3b2784-1880-46ba-8203-ad9ca9ab35a0" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "f7b48542-3b55-4876-b400-02f53a3ea90b", "7b3b2784-1880-46ba-8203-ad9ca9ab35a0" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "f7b48542-3b55-4876-b400-02f53a3ea90b");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "7b3b2784-1880-46ba-8203-ad9ca9ab35a0");

			migrationBuilder.DropColumn(
				name: "IsDeleted",
				table: "Showtimes");

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
		}
	}
}
