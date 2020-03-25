using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMDbApi.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    IMDbId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Released = table.Column<string>(nullable: true),
                    Runtime = table.Column<string>(nullable: true),
                    Rated = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Plot = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Actors = table.Column<string>(nullable: true),
                    Writer = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    imdbRating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.IMDbId);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    IMDbId = table.Column<string>(nullable: false),
                    MovieRating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.UserName, x.IMDbId });
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    IMDbId = table.Column<string>(nullable: true),
                    DateId = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
