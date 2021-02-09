using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Piece",
                columns: table => new
                {
                    PieceId = table.Column<Guid>(nullable: false),
                    BoardPiece = table.Column<int>(nullable: false),
                    BoardColor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piece", x => x.PieceId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Rating = table.Column<int>(maxLength: 4, nullable: false),
                    Color = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Square",
                columns: table => new
                {
                    SquareId = table.Column<Guid>(nullable: false),
                    SquareNumber = table.Column<int>(nullable: false),
                    SquareLetter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Square", x => x.SquareId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    MoveId = table.Column<Guid>(nullable: false),
                    PieceId = table.Column<Guid>(nullable: false),
                    StartSquareSquareId = table.Column<Guid>(nullable: true),
                    EndSquareSquareId = table.Column<Guid>(nullable: true),
                    Check = table.Column<bool>(nullable: false),
                    Take = table.Column<bool>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveId);
                    table.ForeignKey(
                        name: "FK_Moves_Square_EndSquareSquareId",
                        column: x => x.EndSquareSquareId,
                        principalTable: "Square",
                        principalColumn: "SquareId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moves_Piece_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Piece",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moves_Square_StartSquareSquareId",
                        column: x => x.StartSquareSquareId,
                        principalTable: "Square",
                        principalColumn: "SquareId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_EndSquareSquareId",
                table: "Moves",
                column: "EndSquareSquareId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GameId",
                table: "Moves",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PieceId",
                table: "Moves",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_StartSquareSquareId",
                table: "Moves",
                column: "StartSquareSquareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Square");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Piece");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
