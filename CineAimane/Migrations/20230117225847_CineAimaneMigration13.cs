using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration13 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Reservation_Showdates_ShowdateId",
				table: "Reservation");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Reservation",
				table: "Reservation");

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "512e82fd-91bf-4872-8bba-0d23f3ef7195", "c934ee4e-589a-489f-b5de-4334b7e04df4" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "512e82fd-91bf-4872-8bba-0d23f3ef7195");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "c934ee4e-589a-489f-b5de-4334b7e04df4");

			migrationBuilder.RenameTable(
				name: "Reservation",
				newName: "Reservations");

			migrationBuilder.RenameIndex(
				name: "IX_Reservation_ShowdateId",
				table: "Reservations",
				newName: "IX_Reservations_ShowdateId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Reservations",
				table: "Reservations",
				column: "Id");

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

			migrationBuilder.AddForeignKey(
				name: "FK_Reservations_Showdates_ShowdateId",
				table: "Reservations",
				column: "ShowdateId",
				principalTable: "Showdates",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Reservations_Showdates_ShowdateId",
				table: "Reservations");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Reservations",
				table: "Reservations");

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

			migrationBuilder.RenameTable(
				name: "Reservations",
				newName: "Reservation");

			migrationBuilder.RenameIndex(
				name: "IX_Reservations_ShowdateId",
				table: "Reservation",
				newName: "IX_Reservation_ShowdateId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Reservation",
				table: "Reservation",
				column: "Id");

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[] { "512e82fd-91bf-4872-8bba-0d23f3ef7195", "1850336b-9436-42d2-9d6a-8a15690e5c3b", "Admin", "ADMIN" });

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "c934ee4e-589a-489f-b5de-4334b7e04df4", 0, "d72d1912-a4f0-4b1f-9f90-7c19ba71e617", "aimanecouissi@gmail.com", true, true, null, "AIMANECOUISSI@GMAIL.COM", "AIMANECOUISSI", "AQAAAAEAACcQAAAAEPJ4zPGIWY63hCLOOrWIHLHaWSuZCo6JLVUou+s1C/XhxyqalsMfr7WEcnzqBBljqg==", null, false, "72d62ced-1de2-41a6-9640-d2419f52f063", false, "aimanecouissi" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "512e82fd-91bf-4872-8bba-0d23f3ef7195", "c934ee4e-589a-489f-b5de-4334b7e04df4" });

			migrationBuilder.AddForeignKey(
				name: "FK_Reservation_Showdates_ShowdateId",
				table: "Reservation",
				column: "ShowdateId",
				principalTable: "Showdates",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
