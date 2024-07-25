using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterSlayerReborn.Repo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGamePlayerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Player_playerId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameColumn(
                name: "playerId",
                table: "Games",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_playerId",
                table: "Games",
                newName: "IX_Games_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Games",
                newName: "playerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                newName: "IX_Games_playerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Player_playerId",
                table: "Games",
                column: "playerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
