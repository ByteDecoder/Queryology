using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ByteDecoder.Queryology.Example.Migrations
{
  public partial class InitialMigration : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Authors",
          columns: table => new
          {
            AuthorId = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Name = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Authors", x => x.AuthorId);
          });

      migrationBuilder.CreateTable(
          name: "Books",
          columns: table => new
          {
            BookId = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Title = table.Column<string>(nullable: true),
            Description = table.Column<string>(nullable: true),
            PublishedOn = table.Column<DateTime>(nullable: false),
            Publisher = table.Column<string>(nullable: true),
            Price = table.Column<decimal>(nullable: false),
            ImageUrl = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Books", x => x.BookId);
          });

      migrationBuilder.CreateTable(
          name: "BookAuthor",
          columns: table => new
          {
            BookId = table.Column<int>(nullable: false),
            AuthorId = table.Column<int>(nullable: false),
            Order = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_BookAuthor", x => new { x.BookId, x.AuthorId });
            table.ForeignKey(
                      name: "FK_BookAuthor_Authors_AuthorId",
                      column: x => x.AuthorId,
                      principalTable: "Authors",
                      principalColumn: "AuthorId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_BookAuthor_Books_BookId",
                      column: x => x.BookId,
                      principalTable: "Books",
                      principalColumn: "BookId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "PriceOffers",
          columns: table => new
          {
            PriceOfferId = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            NewPrice = table.Column<decimal>(nullable: false),
            PromotionalText = table.Column<string>(nullable: true),
            BookId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_PriceOffers", x => x.PriceOfferId);
            table.ForeignKey(
                      name: "FK_PriceOffers_Books_BookId",
                      column: x => x.BookId,
                      principalTable: "Books",
                      principalColumn: "BookId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Review",
          columns: table => new
          {
            ReviewId = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            VoterName = table.Column<string>(nullable: true),
            NumStars = table.Column<int>(nullable: false),
            Comment = table.Column<string>(nullable: true),
            BookId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Review", x => x.ReviewId);
            table.ForeignKey(
                      name: "FK_Review_Books_BookId",
                      column: x => x.BookId,
                      principalTable: "Books",
                      principalColumn: "BookId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.InsertData(
          table: "Authors",
          columns: new[] { "AuthorId", "Name" },
          values: new object[] { 1, "Mary Hogan" });

      migrationBuilder.InsertData(
          table: "Authors",
          columns: new[] { "AuthorId", "Name" },
          values: new object[] { 2, "Molly Kramer" });

      migrationBuilder.InsertData(
          table: "Authors",
          columns: new[] { "AuthorId", "Name" },
          values: new object[] { 3, "Rhonda Ferguson" });

      migrationBuilder.InsertData(
          table: "Authors",
          columns: new[] { "AuthorId", "Name" },
          values: new object[] { 4, "Jessie Salinas" });

      migrationBuilder.InsertData(
          table: "Authors",
          columns: new[] { "AuthorId", "Name" },
          values: new object[] { 5, "Maryam Jenkins" });

      migrationBuilder.InsertData(
          table: "Authors",
          columns: new[] { "AuthorId", "Name" },
          values: new object[] { 6, "Adele Gonzalez" });

      migrationBuilder.InsertData(
          table: "Authors",
          columns: new[] { "AuthorId", "Name" },
          values: new object[] { 7, "Yasmine Chapman" });

      migrationBuilder.InsertData(
          table: "Books",
          columns: new[] { "BookId", "Description", "ImageUrl", "Price", "PublishedOn", "Publisher", "Title" },
          values: new object[] { 1, "Learn C# Series", "www.sample.com", 25.00m, new DateTime(2002, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ematoma United", "C# Volume 1" });

      migrationBuilder.InsertData(
          table: "Books",
          columns: new[] { "BookId", "Description", "ImageUrl", "Price", "PublishedOn", "Publisher", "Title" },
          values: new object[] { 2, "Learn C# Series", "www.sample.com", 27.00m, new DateTime(2003, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ematoma United", "C# Volume 2" });

      migrationBuilder.InsertData(
          table: "Books",
          columns: new[] { "BookId", "Description", "ImageUrl", "Price", "PublishedOn", "Publisher", "Title" },
          values: new object[] { 3, "Learn C# Series", "www.sample.com", 30.00m, new DateTime(2004, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ematoma United", "C# Volume 3" });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 1, 5, 1 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 3, 3, 3 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 3, 2, 2 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 3, 1, 1 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 3, 6, 6 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 3, 7, 7 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 3, 4, 4 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 2, 7, 3 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 2, 1, 1 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 1, 2, 3 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 1, 7, 2 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 2, 4, 2 });

      migrationBuilder.InsertData(
          table: "BookAuthor",
          columns: new[] { "BookId", "AuthorId", "Order" },
          values: new object[] { 3, 5, 5 });

      migrationBuilder.InsertData(
          table: "PriceOffers",
          columns: new[] { "PriceOfferId", "BookId", "NewPrice", "PromotionalText" },
          values: new object[] { 2, 2, 23.99m, "Do not be behind!!!" });

      migrationBuilder.InsertData(
          table: "PriceOffers",
          columns: new[] { "PriceOfferId", "BookId", "NewPrice", "PromotionalText" },
          values: new object[] { 1, 1, 15.00m, "Get the saga!!!" });

      migrationBuilder.InsertData(
          table: "Review",
          columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
          values: new object[] { 5, 3, "So radiant and splendid!!", 5, "Jacinto Squire" });

      migrationBuilder.InsertData(
          table: "Review",
          columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
          values: new object[] { 6, 3, "This shot blew my mind.", 3, "Julia Akashiya" });

      migrationBuilder.InsertData(
          table: "Review",
          columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
          values: new object[] { 4, 2, "Nice use of magenta in this concept!", 3, "Lucretia Wells" });

      migrationBuilder.InsertData(
          table: "Review",
          columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
          values: new object[] { 3, 2, "Outstandingly thought out! This is new school.", 5, "Jacinto Squire" });

      migrationBuilder.InsertData(
          table: "Review",
          columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
          values: new object[] { 2, 1, "Noyhing to say...", 3, "Lucretia Wells" });

      migrationBuilder.InsertData(
          table: "Review",
          columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
          values: new object[] { 1, 1, "Supper Lupper", 5, "Jacinto Squire" });

      migrationBuilder.InsertData(
          table: "Review",
          columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
          values: new object[] { 7, 3, "Fabulous work you have here.", 5, "Morgana Avila" });

      migrationBuilder.InsertData(
          table: "Review",
          columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
          values: new object[] { 8, 3, "This shapes has navigated right into my heart.", 3, "Danica Ayala" });

      migrationBuilder.CreateIndex(
          name: "IX_BookAuthor_AuthorId",
          table: "BookAuthor",
          column: "AuthorId");

      migrationBuilder.CreateIndex(
          name: "IX_PriceOffers_BookId",
          table: "PriceOffers",
          column: "BookId",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Review_BookId",
          table: "Review",
          column: "BookId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "BookAuthor");

      migrationBuilder.DropTable(
          name: "PriceOffers");

      migrationBuilder.DropTable(
          name: "Review");

      migrationBuilder.DropTable(
          name: "Authors");

      migrationBuilder.DropTable(
          name: "Books");
    }
  }
}
