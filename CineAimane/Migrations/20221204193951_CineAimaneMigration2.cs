using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineAimane.Migrations
{
	/// <inheritdoc />
	public partial class CineAimaneMigration2 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "Showtimes",
				table: "Movies",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Showtimes",
				table: "Movies");
		}
	}
}
