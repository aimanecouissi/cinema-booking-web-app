using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration14 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "643cb860-2704-42f8-a57a-dd30ee68e880", "6e88d65e-b4d2-46cb-9428-3d22ee10346e" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "643cb860-2704-42f8-a57a-dd30ee68e880");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "6e88d65e-b4d2-46cb-9428-3d22ee10346e");

			migrationBuilder.AlterColumn<string>(
				name: "Email",
				table: "Reservations",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[] { "ecee7176-9f65-468a-a0e0-544543ccf605", "f6f16544-b679-48ed-8513-d3d960d9507c", "Admin", "ADMIN" });

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "1beea0be-b9a4-4f10-aeb1-8df3cafa6627", 0, "f3e57121-53cc-43fb-b4de-196b93964b2a", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEAKYkGvyrL3xSojbKCgWLskQ18U7vwfdqN87/0iouMCodG1uYPkIyG7ZtNFg337Q0g==", null, false, "14d7aecd-4bca-4688-b2e4-991cee48c967", false, "aimanecouissi" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "ecee7176-9f65-468a-a0e0-544543ccf605", "1beea0be-b9a4-4f10-aeb1-8df3cafa6627" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "ecee7176-9f65-468a-a0e0-544543ccf605", "1beea0be-b9a4-4f10-aeb1-8df3cafa6627" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "ecee7176-9f65-468a-a0e0-544543ccf605");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "1beea0be-b9a4-4f10-aeb1-8df3cafa6627");

			migrationBuilder.AlterColumn<string>(
				name: "Email",
				table: "Reservations",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[] { "643cb860-2704-42f8-a57a-dd30ee68e880", "14ccd28a-dd02-431d-9538-831d219f535b", "Admin", "ADMIN" });

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "6e88d65e-b4d2-46cb-9428-3d22ee10346e", 0, "04339988-62dc-40b7-b756-6bc18fc2d61a", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEG5BlL9rZBsOOp3UTpZID7buieDXDOu7/9fOQmf2J6f9nNHM03xbOlbjkCuZIrJ0uQ==", null, false, "2caf3ecf-3f64-4985-ac5f-60fc0aa45ff1", false, "aimanecouissi" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "643cb860-2704-42f8-a57a-dd30ee68e880", "6e88d65e-b4d2-46cb-9428-3d22ee10346e" });
		}
	}
}
