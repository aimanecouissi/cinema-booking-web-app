using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	public partial class CineAimaneMigration12 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
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

			migrationBuilder.CreateTable(
				name: "Reservation",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ShowdateId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Reservation", x => x.Id);
					table.ForeignKey(
						name: "FK_Reservation_Showdates_ShowdateId",
						column: x => x.ShowdateId,
						principalTable: "Showdates",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

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

			migrationBuilder.CreateIndex(
				name: "IX_Reservation_ShowdateId",
				table: "Reservation",
				column: "ShowdateId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Reservation");

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
	}
}
