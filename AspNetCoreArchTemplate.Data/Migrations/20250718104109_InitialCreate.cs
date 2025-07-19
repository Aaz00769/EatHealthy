using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreArchTemplate.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Product ID"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "Product name"),
                    Calories = table.Column<int>(type: "int", nullable: false, comment: "Calories per 100g"),
                    Proteins = table.Column<int>(type: "int", nullable: true, comment: "Proteins per 100g (g)"),
                    Fats = table.Column<int>(type: "int", nullable: true, comment: "Fats per 100g (g)"),
                    Carbohydrates = table.Column<int>(type: "int", nullable: true, comment: "Carbohydrates per 100g (g)"),
                    ServingSizeGrams = table.Column<int>(type: "int", nullable: true, comment: "Standard serving size in grams")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                },
                comment: "Product");

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Fats", "Name", "Proteins", "ServingSizeGrams" },
                values: new object[,]
                {
                    { new Guid("02b632ed-4ce6-43e6-96f1-2c76351d2e14"), 120, null, null, "Quinoa", null, null },
                    { new Guid("1508009a-e861-4dc3-a44d-0dffb32b21b6"), 41, null, null, "Carrot", null, null },
                    { new Guid("22d3eb52-22a0-410f-b399-89f1e8b20773"), 208, null, null, "Salmon", null, null },
                    { new Guid("22f2d521-f93b-4fdc-9d0d-4d0c913b3cac"), 127, null, null, "Kidney Beans", null, null },
                    { new Guid("263e5267-2637-40ba-9412-3f226b1b3afc"), 598, null, null, "Dark Chocolate (85%)", null, null },
                    { new Guid("2d21ce5b-fe89-44e9-bbf5-a9de0bf47973"), 155, null, null, "Egg", null, null },
                    { new Guid("2f70b5d1-73a6-4be1-8518-eb75c888189d"), 277, null, null, "Dates", null, null },
                    { new Guid("2f987c6f-0860-4824-ad71-46bbb582253d"), 76, null, null, "Tofu", null, null },
                    { new Guid("3485f0ee-771a-47a6-bb38-866fb92c27e9"), 26, null, null, "Pumpkin", null, null },
                    { new Guid("3549960a-2c32-4149-9497-936fc53c6b5d"), 22, null, null, "Mushrooms", null, null },
                    { new Guid("3ad573e5-bda1-4b00-a4e2-ca532db7b294"), 57, null, null, "Blueberries", null, null },
                    { new Guid("3c6b4530-4599-48a3-8037-83eb1ab490b8"), 116, null, null, "Lentils", null, null },
                    { new Guid("45109a13-9b17-4f6a-8744-228ec63ead77"), 1, null, null, "Green Tea", null, null },
                    { new Guid("45f3fd0a-ed02-449d-aec9-9f96f92d35d2"), 230, null, null, "Coconut Milk", null, null },
                    { new Guid("46c76cbb-a166-4498-817a-5c0b37f4c75b"), 61, null, null, "Milk (Whole)", null, null },
                    { new Guid("4eabf8d4-ce2f-4e10-aef3-4511256c91f5"), 86, null, null, "Sweet Potato", null, null },
                    { new Guid("557b1505-97c3-43b1-9037-473b2cd3ce93"), 579, null, null, "Almonds", null, null },
                    { new Guid("59c5cb91-533a-47e6-9d25-91f32c444dd0"), 250, null, null, "Beef (Lean)", null, null },
                    { new Guid("604c5052-e0cb-470f-8edf-947d1d5039b1"), 98, null, null, "Cottage Cheese", null, null },
                    { new Guid("74ef7bae-d2c6-4a1b-9e57-6fcb965b6aed"), 354, null, null, "Barley", null, null },
                    { new Guid("7b767862-66d7-4ace-83b7-51613252c685"), 52, null, null, "Apple", null, null },
                    { new Guid("83985cba-f3ef-45f2-a0bc-2ea8b5657afd"), 59, null, null, "Greek Yogurt", null, null },
                    { new Guid("8729ce1d-5e20-4ac8-8e88-b6e460e5d027"), 30, null, null, "Watermelon", null, null },
                    { new Guid("885e49e6-1710-4876-b15b-73a8cf271ec5"), 81, null, null, "Green Peas", null, null },
                    { new Guid("8b5f3fe7-835c-466e-8aa4-63af338688c4"), 389, null, null, "Oats", null, null },
                    { new Guid("9153ed88-afaa-44d2-ba48-1c1166c17295"), 132, null, null, "Tuna (Canned in Water)", null, null },
                    { new Guid("9bb8b0d0-c86f-44a1-8d82-20df6159d903"), 123, null, null, "Brown Rice", null, null },
                    { new Guid("9d92bd77-34ff-4a83-a0f4-a6e74cfe13f4"), 132, null, null, "Black Beans", null, null },
                    { new Guid("9dfcf6ca-b86e-423f-98c0-bb710cdf4f93"), 23, null, null, "Spinach", null, null },
                    { new Guid("a7105290-975e-44ae-9e91-c990bc075e5e"), 50, null, null, "Pineapple", null, null },
                    { new Guid("b326bf6a-9a29-443d-9918-872bf574fd7e"), 32, null, null, "Strawberries", null, null },
                    { new Guid("b53a5bb0-6b7a-4982-9026-3ec5983aff57"), 160, null, null, "Avocado", null, null },
                    { new Guid("bca1c0d6-266b-4c1d-8384-bb3a404c214b"), 47, null, null, "Orange", null, null },
                    { new Guid("bd32f447-68dc-433b-ad8f-bfcad40db48c"), 52, null, null, "Raspberries", null, null },
                    { new Guid("beae335b-50dd-4731-b5bd-061c54d0f476"), 77, null, null, "Potato", null, null },
                    { new Guid("c3d8f3ce-1195-410d-8bcc-6e29264150a0"), 403, null, null, "Cheddar Cheese", null, null },
                    { new Guid("c73429f2-e2eb-4a1d-a52d-1563f52f9ea2"), 89, null, null, "Banana", null, null },
                    { new Guid("c98328ca-7671-4636-8711-a40229b0f6ab"), 16, null, null, "Cucumber", null, null },
                    { new Guid("d25aeaa7-bc83-4117-adb5-4c8bad358282"), 25, null, null, "Cauliflower", null, null },
                    { new Guid("d9490ea2-dc8a-4ea2-aef0-988db57b652f"), 18, null, null, "Tomato", null, null },
                    { new Guid("e0731bd3-4ee2-4e3d-b300-75651f24a76c"), 25, null, null, "Eggplant", null, null },
                    { new Guid("e4c9c62d-b13b-4643-9e12-25bad72a48d1"), 99, null, null, "Shrimp", null, null },
                    { new Guid("e66f7950-0102-417c-b7e9-d5529f69d9aa"), 164, null, null, "Chickpeas", null, null },
                    { new Guid("ea124436-a1fb-4afd-8a46-b61adb78b469"), 15, null, null, "Lettuce", null, null },
                    { new Guid("eb34f2c4-f444-40e0-bb47-0d214c3a94a5"), 17, null, null, "Zucchini", null, null },
                    { new Guid("ec86b662-9b24-4838-b206-41905882cd5d"), 304, null, null, "Honey", null, null },
                    { new Guid("f1fe4e41-bce2-4b75-ad3d-1d6b750804a8"), 165, null, null, "Chicken Breast", null, null },
                    { new Guid("f36ec06d-e355-4b63-a59c-91fcef5e0545"), 34, null, null, "Broccoli", null, null },
                    { new Guid("fd1d1dde-c6f9-411d-83c1-09d30f1e32dd"), 588, null, null, "Peanut Butter", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RecipeProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
