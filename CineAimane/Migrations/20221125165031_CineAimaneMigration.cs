using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	/// <inheritdoc />
	public partial class CineAimaneMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Admins",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Admins", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Movies",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					Genres = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Rating = table.Column<int>(type: "int", nullable: false),
					Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Cast = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Backdrop = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Trailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Movies", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Admins");

			migrationBuilder.DropTable(
				name: "Movies");
		}
	}
}
