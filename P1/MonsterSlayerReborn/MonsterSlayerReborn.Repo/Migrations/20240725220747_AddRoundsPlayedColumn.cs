using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterSlayerReborn.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AddRoundsPlayedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roundsPlayed",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
