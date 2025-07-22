using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreArchTemplate.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialidentityCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ServingSizeGrams = table.Column<int>(type: "int", nullable: true, comment: "Standard serving size in grams"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Used to check if itme is Soft Delited")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                },
                comment: "Product");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the day"),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Optional description (e.g., chopped, grilled, peeled)"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date this plan is for (e.g., 2025-07-21)"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ID of the user who created this Day"),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Whether the user has marked this day as completed")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Represents a user's day which contains meals");

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the meal"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the meal (e.g., Breakfast, Snack, Post-Workout)"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ID of the user who created this meal"),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Optional note (e.g., mood, hunger level, etc.)"),
                    TimeEaten = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Timestamp when the meal was consumed (optional)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "A specific meal in a day (e.g., breakfast, lunch, dinner)");

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the recipe"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "Name of the recipe (e.g., Chicken Stir Fry)"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Optional description or instructions for the recipe"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ID of the user who created this recipe"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Used to check if item is Soft Delited"),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, comment: "Whether the user has marked this recipe as public"),
                    IsApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "Whether an administrator has approved the recipe for public visibility"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the recipe was created (UTC)"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time when the recipe was last modified (nullable)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "User-created recipe");

            migrationBuilder.CreateTable(
                name: "DayMeals",
                columns: table => new
                {
                    DayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the Day"),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the Meal"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the DayMeal record"),
                    Order = table.Column<int>(type: "int", nullable: false, comment: "Order of the meal within the day (e.g., 1 = breakfast, 2 = lunch)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayMeals", x => new { x.DayId, x.MealId });
                    table.ForeignKey(
                        name: "FK_DayMeals_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Links a Meal to a Day, allowing reuse across days");

            migrationBuilder.CreateTable(
                name: "MealRecipes",
                columns: table => new
                {
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the related Meal"),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the related Recipe"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the junction record")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRecipes", x => new { x.MealId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_MealRecipes_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Links a Recipe to a Meal");

            migrationBuilder.CreateTable(
                name: "RecipeProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the relation"),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the related recipe"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the related product"),
                    Grams = table.Column<int>(type: "int", nullable: false, comment: "Amount of the product in grams"),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Optional note about the product"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Times Product is used in Recepie")
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
                    { new Guid("05770f97-a16b-422c-90bc-aa35c1eff66d"), 132, null, null, "Tuna (Canned in Water)", null, null },
                    { new Guid("05e5ba84-5358-44e8-8a25-b6977839e016"), 81, null, null, "Green Peas", null, null },
                    { new Guid("18220028-e2a5-49c6-b2a2-91887b2cf113"), 57, null, null, "Blueberries", null, null },
                    { new Guid("215326b5-f336-4171-9d4c-c767bc6abb19"), 17, null, null, "Zucchini", null, null },
                    { new Guid("281789be-0e78-4da7-96d8-e4827bca5e33"), 304, null, null, "Honey", null, null },
                    { new Guid("28f4f59c-bcf1-400a-bd8a-aa509e25d736"), 588, null, null, "Peanut Butter", null, null },
                    { new Guid("2d5b8c03-c762-43fe-8917-303d94653046"), 277, null, null, "Dates", null, null },
                    { new Guid("2d7c3a52-948a-445e-8285-aa5d304c69b4"), 230, null, null, "Coconut Milk", null, null },
                    { new Guid("426b58ce-806e-468c-b066-1b906ff682a1"), 98, null, null, "Cottage Cheese", null, null },
                    { new Guid("51e2d800-22f6-4101-938c-131cc4d51c88"), 59, null, null, "Greek Yogurt", null, null },
                    { new Guid("561e06e0-018f-4f09-8775-026f07f39575"), 123, null, null, "Brown Rice", null, null },
                    { new Guid("56757ff0-d3dc-4051-af61-672e8551faf1"), 52, null, null, "Raspberries", null, null },
                    { new Guid("641a01b3-7aac-4145-ac84-7244cda17f67"), 18, null, null, "Tomato", null, null },
                    { new Guid("66033573-fdda-4d5e-aa4b-673cc6b108ac"), 132, null, null, "Black Beans", null, null },
                    { new Guid("6aa26ed7-5543-4cb3-996c-0b7c2fb769e8"), 127, null, null, "Kidney Beans", null, null },
                    { new Guid("7383a44e-e18e-43aa-8832-11d5f9f49c48"), 76, null, null, "Tofu", null, null },
                    { new Guid("75c6030a-c996-44a7-926e-2e7da3c29538"), 86, null, null, "Sweet Potato", null, null },
                    { new Guid("77ec2562-1d33-4f1b-ac84-44cac043f936"), 23, null, null, "Spinach", null, null },
                    { new Guid("7978efc9-f408-4a63-a054-7ef220386f78"), 160, null, null, "Avocado", null, null },
                    { new Guid("7f6ec167-5675-483b-87f6-382fcc7fe06f"), 208, null, null, "Salmon", null, null },
                    { new Guid("80362d0a-e524-4f9c-8d91-3ef15dc519ca"), 30, null, null, "Watermelon", null, null },
                    { new Guid("86425828-9f1a-45da-ae34-780ce4682c43"), 52, null, null, "Apple", null, null },
                    { new Guid("88486682-23a1-4261-b958-d31b7db661c4"), 41, null, null, "Carrot", null, null },
                    { new Guid("8993c808-9d99-4b5e-b7bd-60ae434d8588"), 116, null, null, "Lentils", null, null },
                    { new Guid("8b4958d1-40f8-4e9f-93db-32c5e1b08290"), 1, null, null, "Green Tea", null, null },
                    { new Guid("970a87c5-ebfb-4d64-a335-5564a75f9a96"), 25, null, null, "Cauliflower", null, null },
                    { new Guid("98651fb6-9a15-458b-a4de-662b7fe95d9d"), 389, null, null, "Oats", null, null },
                    { new Guid("9e491b9e-6558-4918-885f-97613d79a5ba"), 99, null, null, "Shrimp", null, null },
                    { new Guid("a8c4faa7-489c-4461-85ee-e52753f30679"), 16, null, null, "Cucumber", null, null },
                    { new Guid("a919b91a-5cea-44aa-b541-25c3b6f1c4a0"), 61, null, null, "Milk (Whole)", null, null },
                    { new Guid("aae46cc3-a20b-4b15-807a-48dc7efd29df"), 155, null, null, "Egg", null, null },
                    { new Guid("b1f8ae26-1b60-489d-9388-550c5e8ac83e"), 579, null, null, "Almonds", null, null },
                    { new Guid("ba9fc0c3-61aa-4223-b98a-fd53032c4c32"), 165, null, null, "Chicken Breast", null, null },
                    { new Guid("c471023f-1c6c-411d-97bc-ff07485168fc"), 164, null, null, "Chickpeas", null, null },
                    { new Guid("c58becf0-10c2-4794-9a70-92c5a44fb87e"), 250, null, null, "Beef (Lean)", null, null },
                    { new Guid("c635e243-ef45-4683-8bd2-31872bc6fcd7"), 598, null, null, "Dark Chocolate (85%)", null, null },
                    { new Guid("cabc8591-514f-480b-bb0c-6ef75888e554"), 47, null, null, "Orange", null, null },
                    { new Guid("cc6ed89a-d447-469b-ba42-6878bd3e3bb1"), 22, null, null, "Mushrooms", null, null },
                    { new Guid("d07a2589-e704-4171-9ead-386e49ecb992"), 89, null, null, "Banana", null, null },
                    { new Guid("d116f811-ebf3-46e5-8cae-10dfd0d2455e"), 26, null, null, "Pumpkin", null, null },
                    { new Guid("dfe6702a-e5f2-43a7-a8a2-463265b6f611"), 50, null, null, "Pineapple", null, null },
                    { new Guid("e123af4a-53e2-46b2-b98a-3e5dd0cf5e20"), 354, null, null, "Barley", null, null },
                    { new Guid("e4dd33c0-f1be-4c39-a922-59a53d016630"), 34, null, null, "Broccoli", null, null },
                    { new Guid("e85b319b-2c9c-4ee5-bd39-8baf84528ba2"), 403, null, null, "Cheddar Cheese", null, null },
                    { new Guid("ebe0df5c-56e3-4cb6-b903-7e787427be70"), 32, null, null, "Strawberries", null, null },
                    { new Guid("f5abc0c7-c33e-4eac-82a0-9ff21bd5790f"), 120, null, null, "Quinoa", null, null },
                    { new Guid("f822a772-b238-4cbe-9d63-39af63df2f91"), 77, null, null, "Potato", null, null },
                    { new Guid("fcca6803-66f8-4d93-b9d7-9331bc31899e"), 15, null, null, "Lettuce", null, null },
                    { new Guid("fe2baa79-9a71-4594-8915-61901b6c9e5a"), 25, null, null, "Eggplant", null, null }
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
                name: "IX_DayMeals_MealId",
                table: "DayMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_CreatedByUserId",
                table: "Days",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealRecipes_RecipeId",
                table: "MealRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CreatedByUserId",
                table: "Meals",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_ProductId",
                table: "RecipeProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_RecipeId",
                table: "RecipeProducts",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatedByUserId",
                table: "Recipes",
                column: "CreatedByUserId");
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
                name: "DayMeals");

            migrationBuilder.DropTable(
                name: "MealRecipes");

            migrationBuilder.DropTable(
                name: "RecipeProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
