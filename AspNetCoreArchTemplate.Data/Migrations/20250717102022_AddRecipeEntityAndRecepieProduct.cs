using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreArchTemplate.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeEntityAndRecepieProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                },
                comment: "User-created recipe");

            migrationBuilder.CreateTable(
                name: "RecipeProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary Key"),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign Key to Recipe"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign Key to Product"),
                    Grams = table.Column<int>(type: "int", nullable: false, comment: "Amount of the product in grams"),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Optional note about the product")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeProducts_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Links a Product to a Recipe with a specific amount");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_ProductId",
                table: "RecipeProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_RecipeId",
                table: "RecipeProducts",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeProducts");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
