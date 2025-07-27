using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreArchTemplate.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReworkedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b9270a4-14e1-4fff-9708-800352cd9d37"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ca40189-a8ac-4f7e-bdfe-310c8004263e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e0988dc-bb49-4416-8b4b-df01d347f393"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f675952-5098-4056-90bd-44eb432b8801"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f4de49-4dba-4eba-8a22-c7f0d790c52b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("15c48689-fbe4-4cd0-9ad5-0f0b15fc2811"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2a25c888-1f8d-415a-8089-493574896c8e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b6bfa28-1fbf-4cf9-b03a-5d76ff5ccacf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3762244b-17e2-4f6d-9673-3437e67bd3b8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a051a4c-9db8-467b-a334-da39b7e644cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("41bae366-919f-404e-a868-5be5abfb29fa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("47ba055c-b8e9-4dcf-85bd-8f541eebde26"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b52b09b-9cce-4c01-b7a4-94eb5e60917e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("603e1dc5-2dcc-462e-8526-a37ce236c38f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("63e02e23-060e-4b3f-9c36-409055d65277"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("65e77d99-d0aa-41e0-a520-a10eb359e93e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("666623a5-650f-4318-b84f-4ae713971b15"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("67c4d6ac-d592-40d3-8405-e9819911ab6c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6aadaa3f-094b-400f-b367-3e65e4f7f8c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6c846acf-56d0-40b5-af36-7fbcc1a5abd5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f1403f5-de43-4322-8497-8a052e247f4b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6ffa00b5-1931-4b4f-8906-377849069338"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7956d98a-e774-45a4-abde-ca384b7a206b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bc98760-501d-4588-8ff0-10cc9a836388"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("839f760c-1fc1-471b-b792-3f29c0514e15"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("863b0728-427e-4bf7-aa68-19b7ff62ff5e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86968fe4-dea4-4763-a36f-651d96c88818"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8d14123a-1812-4c9c-8228-61fc13cbe7f3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("909fc1b5-92e2-4d28-ba53-f730a465b66d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90d1c1fd-64bc-4538-a5bb-7f864fe8e0d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("926dbc78-0d1a-4a4f-a0ac-4234477b9094"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("92758d68-c3b1-479a-ab66-8e77aa5534cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("97ac88d0-75e5-4fd2-a7d0-f28c74a7ce6d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("997009f8-3f43-4ad9-80a2-978ddb5d3e94"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9996f647-5a73-424a-9bef-ba4298d318c7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a7fc873-0623-4445-9747-64888595d582"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9bae4a15-a057-4ece-a26f-213631f3bdce"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9e1c983f-83f0-415d-bd1d-55ddfc1e687e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f7288af-589c-4212-a382-dc78bba0756c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ab82fd1f-deb0-421d-b9df-d8e7ccec133d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("accefa04-227b-476a-9751-69e611c6674c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("af057d37-1c5a-4f79-82ff-ffc7a0e882e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2ac21c3-586c-4558-b8bd-bcf2ecdd188d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2e8a402-d502-4919-9b51-a981a4750c73"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b67c1fef-b404-4df6-a1fc-d613eaba6a50"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c4ddd2bd-3145-42ce-a203-004bf50ffbab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cde489d7-65cc-4df6-a31e-f42f1368143c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d8d51af0-e18e-4053-92ff-36805cf13ae3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f53cd299-ce5d-4a80-99e0-478b34c1debc"));

            migrationBuilder.DropColumn(
                name: "TimeEaten",
                table: "Meals");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Meals",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Used to check if itme is Soft Delited");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Days",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Used to check if itme is Soft Delited");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Fats", "Name", "Proteins", "ServingSizeGrams" },
                values: new object[,]
                {
                    { new Guid("01619522-6036-4335-90d9-614e8eae486a"), 98, null, null, "Cottage Cheese", null, null },
                    { new Guid("0acb7b2e-cfc6-46ef-b216-34d57df6bf74"), 389, null, null, "Oats", null, null },
                    { new Guid("0e57ab1d-f73b-46e2-85e5-b05e0794fd16"), 81, null, null, "Green Peas", null, null },
                    { new Guid("0f538dc5-2e52-4873-9997-584046f9e57e"), 50, null, null, "Pineapple", null, null },
                    { new Guid("1927900b-fcba-4ac4-85a7-876059e130c2"), 99, null, null, "Shrimp", null, null },
                    { new Guid("1b3b9a64-36bf-444f-92d1-c428a09b0501"), 25, null, null, "Cauliflower", null, null },
                    { new Guid("2e584faa-bc94-4781-ac3d-7f7d37faa5ca"), 123, null, null, "Brown Rice", null, null },
                    { new Guid("2eb3a9d5-9a6a-440e-89c7-cd11532a2e37"), 588, null, null, "Peanut Butter", null, null },
                    { new Guid("30f60fe2-0b5c-463b-9a89-e30ee8b81058"), 22, null, null, "Mushrooms", null, null },
                    { new Guid("346e1f53-fef9-43fd-90f6-55fea3a1cadf"), 86, null, null, "Sweet Potato", null, null },
                    { new Guid("42a89a46-a556-423b-a5f1-c628b3cd981f"), 25, null, null, "Eggplant", null, null },
                    { new Guid("44c4a7fd-029c-4b72-98de-5194fdf52067"), 165, null, null, "Chicken Breast", null, null },
                    { new Guid("46721ae9-660d-49e3-a821-d8741bd97620"), 579, null, null, "Almonds", null, null },
                    { new Guid("492f2429-b6d1-40ef-9e21-8b889ad94e9c"), 15, null, null, "Lettuce", null, null },
                    { new Guid("4a3ee7ec-bb88-49f7-9e22-d6998abea027"), 77, null, null, "Potato", null, null },
                    { new Guid("4dd33b1c-98f8-4615-89d6-ca02be9462e8"), 250, null, null, "Beef (Lean)", null, null },
                    { new Guid("50e4b60e-7cb1-4844-87cc-d60e6299f6dc"), 41, null, null, "Carrot", null, null },
                    { new Guid("50f1c5f1-777d-4dc8-bb7f-741adeba0549"), 598, null, null, "Dark Chocolate (85%)", null, null },
                    { new Guid("5a9e2283-dd49-46c9-82de-43c9932faf03"), 230, null, null, "Coconut Milk", null, null },
                    { new Guid("5cfa7a25-667d-46b4-8fce-3eb51130affe"), 47, null, null, "Orange", null, null },
                    { new Guid("67a4b275-1ea7-46ee-ac19-877acc714018"), 116, null, null, "Lentils", null, null },
                    { new Guid("68ea3bd1-879e-44ee-ab6d-11eb1dca6cc9"), 208, null, null, "Salmon", null, null },
                    { new Guid("776468d5-f2ce-4b27-8512-60f197973f85"), 277, null, null, "Dates", null, null },
                    { new Guid("793bf473-5190-4237-b5a1-2eea77286bc0"), 17, null, null, "Zucchini", null, null },
                    { new Guid("7f377243-43eb-4953-a26f-6889c26d0352"), 164, null, null, "Chickpeas", null, null },
                    { new Guid("83249ca6-1a08-45fd-bb0a-ba6d4de69755"), 132, null, null, "Tuna (Canned in Water)", null, null },
                    { new Guid("87e0ad6e-eb7d-4c57-8d6c-a461a7358271"), 18, null, null, "Tomato", null, null },
                    { new Guid("88db1af0-a20c-4bff-8e25-1a96be2c87c8"), 403, null, null, "Cheddar Cheese", null, null },
                    { new Guid("8cb2cabb-6979-4ad7-b990-7d8883e7d239"), 160, null, null, "Avocado", null, null },
                    { new Guid("98844eee-c900-4c02-82b3-46071f13c3fa"), 61, null, null, "Milk (Whole)", null, null },
                    { new Guid("a6328d92-7558-4124-a9f5-e583e86bd54b"), 30, null, null, "Watermelon", null, null },
                    { new Guid("aa3a01d9-585e-4c36-9f0f-c5be0d336642"), 59, null, null, "Greek Yogurt", null, null },
                    { new Guid("ad20dd99-2cd2-4f5e-a19c-192d43497021"), 89, null, null, "Banana", null, null },
                    { new Guid("adc2f5b7-57a9-417b-a15e-d8a54cbf3d11"), 16, null, null, "Cucumber", null, null },
                    { new Guid("b6212d0e-c59a-4a20-bfaf-12de965f8d50"), 32, null, null, "Strawberries", null, null },
                    { new Guid("b7f6d259-8f2a-428a-868b-f9fc5fd64e70"), 52, null, null, "Raspberries", null, null },
                    { new Guid("bf2047c5-b0ec-498a-bceb-6b80b38d2979"), 52, null, null, "Apple", null, null },
                    { new Guid("bf9d862f-c9cb-40d2-837e-6b503ad9d31c"), 1, null, null, "Green Tea", null, null },
                    { new Guid("c2257661-26a4-4fa6-9807-7dc60abf6422"), 354, null, null, "Barley", null, null },
                    { new Guid("cb1a01b5-44d2-40be-8c6e-67e89f3399dc"), 34, null, null, "Broccoli", null, null },
                    { new Guid("cccc4241-9dfa-4939-8cd4-15fe7b8d2592"), 76, null, null, "Tofu", null, null },
                    { new Guid("db9f45a1-8d40-495e-8401-bd731fc7da4f"), 132, null, null, "Black Beans", null, null },
                    { new Guid("e6126451-660c-4dff-aca3-4355338347a2"), 26, null, null, "Pumpkin", null, null },
                    { new Guid("e73b80b8-4457-421c-9adc-314001209b16"), 127, null, null, "Kidney Beans", null, null },
                    { new Guid("ea63978f-521a-453b-8562-479cf74b7ba7"), 304, null, null, "Honey", null, null },
                    { new Guid("eb7bf1a9-0911-4eb9-9641-b14f651f8e50"), 155, null, null, "Egg", null, null },
                    { new Guid("f1707587-a9a0-487d-bd6c-7aafae963eee"), 57, null, null, "Blueberries", null, null },
                    { new Guid("fbbe152a-aaad-4d0a-b896-a161ad9a772e"), 120, null, null, "Quinoa", null, null },
                    { new Guid("ffe9a987-4f99-497a-b1ed-f87e26b93397"), 23, null, null, "Spinach", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("01619522-6036-4335-90d9-614e8eae486a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0acb7b2e-cfc6-46ef-b216-34d57df6bf74"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e57ab1d-f73b-46e2-85e5-b05e0794fd16"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f538dc5-2e52-4873-9997-584046f9e57e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1927900b-fcba-4ac4-85a7-876059e130c2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b3b9a64-36bf-444f-92d1-c428a09b0501"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e584faa-bc94-4781-ac3d-7f7d37faa5ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2eb3a9d5-9a6a-440e-89c7-cd11532a2e37"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30f60fe2-0b5c-463b-9a89-e30ee8b81058"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("346e1f53-fef9-43fd-90f6-55fea3a1cadf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("42a89a46-a556-423b-a5f1-c628b3cd981f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44c4a7fd-029c-4b72-98de-5194fdf52067"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46721ae9-660d-49e3-a821-d8741bd97620"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("492f2429-b6d1-40ef-9e21-8b889ad94e9c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4a3ee7ec-bb88-49f7-9e22-d6998abea027"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4dd33b1c-98f8-4615-89d6-ca02be9462e8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("50e4b60e-7cb1-4844-87cc-d60e6299f6dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("50f1c5f1-777d-4dc8-bb7f-741adeba0549"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5a9e2283-dd49-46c9-82de-43c9932faf03"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5cfa7a25-667d-46b4-8fce-3eb51130affe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("67a4b275-1ea7-46ee-ac19-877acc714018"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("68ea3bd1-879e-44ee-ab6d-11eb1dca6cc9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("776468d5-f2ce-4b27-8512-60f197973f85"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("793bf473-5190-4237-b5a1-2eea77286bc0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f377243-43eb-4953-a26f-6889c26d0352"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83249ca6-1a08-45fd-bb0a-ba6d4de69755"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("87e0ad6e-eb7d-4c57-8d6c-a461a7358271"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("88db1af0-a20c-4bff-8e25-1a96be2c87c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8cb2cabb-6979-4ad7-b990-7d8883e7d239"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("98844eee-c900-4c02-82b3-46071f13c3fa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a6328d92-7558-4124-a9f5-e583e86bd54b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa3a01d9-585e-4c36-9f0f-c5be0d336642"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad20dd99-2cd2-4f5e-a19c-192d43497021"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("adc2f5b7-57a9-417b-a15e-d8a54cbf3d11"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6212d0e-c59a-4a20-bfaf-12de965f8d50"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7f6d259-8f2a-428a-868b-f9fc5fd64e70"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bf2047c5-b0ec-498a-bceb-6b80b38d2979"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bf9d862f-c9cb-40d2-837e-6b503ad9d31c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c2257661-26a4-4fa6-9807-7dc60abf6422"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb1a01b5-44d2-40be-8c6e-67e89f3399dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cccc4241-9dfa-4939-8cd4-15fe7b8d2592"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db9f45a1-8d40-495e-8401-bd731fc7da4f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6126451-660c-4dff-aca3-4355338347a2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e73b80b8-4457-421c-9adc-314001209b16"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea63978f-521a-453b-8562-479cf74b7ba7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb7bf1a9-0911-4eb9-9641-b14f651f8e50"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1707587-a9a0-487d-bd6c-7aafae963eee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fbbe152a-aaad-4d0a-b896-a161ad9a772e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffe9a987-4f99-497a-b1ed-f87e26b93397"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Days");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeEaten",
                table: "Meals",
                type: "datetime2",
                nullable: true,
                comment: "Timestamp when the meal was consumed (optional)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Fats", "Name", "Proteins", "ServingSizeGrams" },
                values: new object[,]
                {
                    { new Guid("0b9270a4-14e1-4fff-9708-800352cd9d37"), 86, null, null, "Sweet Potato", null, null },
                    { new Guid("0ca40189-a8ac-4f7e-bdfe-310c8004263e"), 98, null, null, "Cottage Cheese", null, null },
                    { new Guid("0e0988dc-bb49-4416-8b4b-df01d347f393"), 389, null, null, "Oats", null, null },
                    { new Guid("0f675952-5098-4056-90bd-44eb432b8801"), 132, null, null, "Tuna (Canned in Water)", null, null },
                    { new Guid("11f4de49-4dba-4eba-8a22-c7f0d790c52b"), 208, null, null, "Salmon", null, null },
                    { new Guid("15c48689-fbe4-4cd0-9ad5-0f0b15fc2811"), 26, null, null, "Pumpkin", null, null },
                    { new Guid("2a25c888-1f8d-415a-8089-493574896c8e"), 89, null, null, "Banana", null, null },
                    { new Guid("2b6bfa28-1fbf-4cf9-b03a-5d76ff5ccacf"), 76, null, null, "Tofu", null, null },
                    { new Guid("3762244b-17e2-4f6d-9673-3437e67bd3b8"), 165, null, null, "Chicken Breast", null, null },
                    { new Guid("3a051a4c-9db8-467b-a334-da39b7e644cb"), 57, null, null, "Blueberries", null, null },
                    { new Guid("41bae366-919f-404e-a868-5be5abfb29fa"), 52, null, null, "Apple", null, null },
                    { new Guid("47ba055c-b8e9-4dcf-85bd-8f541eebde26"), 15, null, null, "Lettuce", null, null },
                    { new Guid("4b52b09b-9cce-4c01-b7a4-94eb5e60917e"), 17, null, null, "Zucchini", null, null },
                    { new Guid("603e1dc5-2dcc-462e-8526-a37ce236c38f"), 50, null, null, "Pineapple", null, null },
                    { new Guid("63e02e23-060e-4b3f-9c36-409055d65277"), 47, null, null, "Orange", null, null },
                    { new Guid("65e77d99-d0aa-41e0-a520-a10eb359e93e"), 16, null, null, "Cucumber", null, null },
                    { new Guid("666623a5-650f-4318-b84f-4ae713971b15"), 59, null, null, "Greek Yogurt", null, null },
                    { new Guid("67c4d6ac-d592-40d3-8405-e9819911ab6c"), 250, null, null, "Beef (Lean)", null, null },
                    { new Guid("6aadaa3f-094b-400f-b367-3e65e4f7f8c8"), 155, null, null, "Egg", null, null },
                    { new Guid("6c846acf-56d0-40b5-af36-7fbcc1a5abd5"), 277, null, null, "Dates", null, null },
                    { new Guid("6f1403f5-de43-4322-8497-8a052e247f4b"), 22, null, null, "Mushrooms", null, null },
                    { new Guid("6ffa00b5-1931-4b4f-8906-377849069338"), 588, null, null, "Peanut Butter", null, null },
                    { new Guid("7956d98a-e774-45a4-abde-ca384b7a206b"), 41, null, null, "Carrot", null, null },
                    { new Guid("7bc98760-501d-4588-8ff0-10cc9a836388"), 120, null, null, "Quinoa", null, null },
                    { new Guid("839f760c-1fc1-471b-b792-3f29c0514e15"), 116, null, null, "Lentils", null, null },
                    { new Guid("863b0728-427e-4bf7-aa68-19b7ff62ff5e"), 598, null, null, "Dark Chocolate (85%)", null, null },
                    { new Guid("86968fe4-dea4-4763-a36f-651d96c88818"), 579, null, null, "Almonds", null, null },
                    { new Guid("8d14123a-1812-4c9c-8228-61fc13cbe7f3"), 123, null, null, "Brown Rice", null, null },
                    { new Guid("909fc1b5-92e2-4d28-ba53-f730a465b66d"), 99, null, null, "Shrimp", null, null },
                    { new Guid("90d1c1fd-64bc-4538-a5bb-7f864fe8e0d3"), 34, null, null, "Broccoli", null, null },
                    { new Guid("926dbc78-0d1a-4a4f-a0ac-4234477b9094"), 25, null, null, "Cauliflower", null, null },
                    { new Guid("92758d68-c3b1-479a-ab66-8e77aa5534cd"), 81, null, null, "Green Peas", null, null },
                    { new Guid("97ac88d0-75e5-4fd2-a7d0-f28c74a7ce6d"), 230, null, null, "Coconut Milk", null, null },
                    { new Guid("997009f8-3f43-4ad9-80a2-978ddb5d3e94"), 403, null, null, "Cheddar Cheese", null, null },
                    { new Guid("9996f647-5a73-424a-9bef-ba4298d318c7"), 61, null, null, "Milk (Whole)", null, null },
                    { new Guid("9a7fc873-0623-4445-9747-64888595d582"), 25, null, null, "Eggplant", null, null },
                    { new Guid("9bae4a15-a057-4ece-a26f-213631f3bdce"), 18, null, null, "Tomato", null, null },
                    { new Guid("9e1c983f-83f0-415d-bd1d-55ddfc1e687e"), 77, null, null, "Potato", null, null },
                    { new Guid("9f7288af-589c-4212-a382-dc78bba0756c"), 160, null, null, "Avocado", null, null },
                    { new Guid("ab82fd1f-deb0-421d-b9df-d8e7ccec133d"), 132, null, null, "Black Beans", null, null },
                    { new Guid("accefa04-227b-476a-9751-69e611c6674c"), 304, null, null, "Honey", null, null },
                    { new Guid("af057d37-1c5a-4f79-82ff-ffc7a0e882e2"), 30, null, null, "Watermelon", null, null },
                    { new Guid("b2ac21c3-586c-4558-b8bd-bcf2ecdd188d"), 52, null, null, "Raspberries", null, null },
                    { new Guid("b2e8a402-d502-4919-9b51-a981a4750c73"), 127, null, null, "Kidney Beans", null, null },
                    { new Guid("b67c1fef-b404-4df6-a1fc-d613eaba6a50"), 32, null, null, "Strawberries", null, null },
                    { new Guid("c4ddd2bd-3145-42ce-a203-004bf50ffbab"), 354, null, null, "Barley", null, null },
                    { new Guid("cde489d7-65cc-4df6-a31e-f42f1368143c"), 1, null, null, "Green Tea", null, null },
                    { new Guid("d8d51af0-e18e-4053-92ff-36805cf13ae3"), 23, null, null, "Spinach", null, null },
                    { new Guid("f53cd299-ce5d-4a80-99e0-478b34c1debc"), 164, null, null, "Chickpeas", null, null }
                });
        }
    }
}
