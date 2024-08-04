using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace INFT3050.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VitaminType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderHistorySubtotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Images_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderItemStubtotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "Category", "Company", "DateAdded", "Description", "ItemName", "Price", "Quantity", "VitaminType" },
                values: new object[,]
                {
                    { 1, "Heart Health", "Ocean Health", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2859), "Ocean Health Omega 3 Fish Oil 1000mg is a 100% natural dietary supplement that is a rich source of the Omega 3 essential fatty acids EPA and DHA derived from deep water fish.", "Omega-3 Fish Oil 1000mg 60s", 24.530000000000001, 10, "Fish Oil" },
                    { 2, "Eye Health", "Holistic Way", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2879), "Holistic Way Children's Eye Lutein Gummy may help to support healthy vision in children. Lutein is a potent antioxidant which helps to filter harmful blue light.", "Eye Lutein Gummy", 39.799999999999997, 2, "Others" },
                    { 3, "Immune System", "Holistic Way", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2881), "Holistic Way Vitamin C supports healthy immune system functioning, eases cold, flu and sore throat and stimulates collagen growth.", "Vitamin C 500mg 60s", 26.0, 15, "Vitamin C" },
                    { 4, "Overall Health", "Centrum", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2883), "Centrum Multivitamins provide essential vitamins and minerals to help support your overall health and well-being.", "Centrum Multivitamin", 50.0, 30, "Multivitamins" },
                    { 5, "Bone Health", "Nature Made", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2885), "Nature Made Calcium 600mg with Vitamin D3 helps support bone health and muscle function.", "Calcium 600mg + Vitamin D3", 22.0, 20, "Calcium" },
                    { 6, "Digestive Health", "Nature's Bounty", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2887), "Nature's Bounty Probiotic 10 contains 10 unique probiotic strains to support digestive health.", "Probiotic 10", 30.0, 15, "Probiotics" },
                    { 7, "Heart Health", "Nature's Bounty", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2889), "Nature's Bounty CoQ10 200mg supports heart health and energy production.", "CoQ10 200mg", 40.0, 10, "CoQ10" },
                    { 8, "Beauty", "Nature's Bounty", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2891), "Nature's Bounty Biotin supports healthy hair, skin, and nails.", "Biotin 5000mcg", 15.0, 25, "Biotin" },
                    { 9, "Bone Health", "Nature Made", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2892), "Nature Made Vitamin D3 1000 IU supports bone and immune health.", "Vitamin D3 1000 IU", 15.0, 20, "Vitamin D" },
                    { 10, "Heart Health", "Nordic Naturals", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2894), "Nordic Naturals Fish Oil 1200mg supports heart health and cognitive function.", "Fish Oil 1200mg", 25.0, 22, "Fish Oil" },
                    { 11, "Joint Health", "Nordic Naturals", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2896), "Nordic Naturals Curcumin 200mg supports joint health and inflammatory response.", "Curcumin 200mg", 35.0, 15, "Curcumin" },
                    { 12, "Digestive Health", "Nordic Naturals", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2898), "Nordic Naturals Probiotic Gummies support digestive health.", "Probiotic Gummies", 20.0, 25, "Probiotics" },
                    { 13, "Beauty", "Vital Proteins", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2900), "Vital Proteins Collagen Peptides support skin, hair, nail, and joint health.", "Collagen Peptides", 40.0, 20, "Collagen" },
                    { 14, "Immune System", "Vitafusion", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2901), "Vitafusion Vitamin C Gummies support immune system health.", "Vitamin C Gummies", 15.0, 30, "Vitamin C" },
                    { 15, "Overall Health", "Vitafusion", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2903), "Vitafusion Women's Multivitamin supports overall women's health.", "Women's Multivitamin", 25.0, 35, "Multivitamins" },
                    { 16, "Sleep Health", "Vitafusion", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2905), "Vitafusion Melatonin 5mg supports healthy sleep patterns.", "Melatonin 5mg", 10.0, 28, "Melatonin" },
                    { 17, "Energy", "Solgar", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2907), "Solgar Vitamin B Complex supports energy metabolism.", "Vitamin B Complex", 20.0, 20, "Vitamin B" },
                    { 18, "Overall Health", "Solgar", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2909), "Solgar Magnesium Citrate supports nerve and muscle function.", "Magnesium Citrate", 15.0, 18, "Magnesium" },
                    { 19, "Heart Health", "Solgar", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2911), "Solgar Folate 400mcg supports heart health and cellular function.", "Folate 400mcg", 12.0, 22, "Folate" },
                    { 20, "Immune System", "Solgar", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2913), "Solgar Vitamin E 200 IU supports immune and skin health.", "Vitamin E 200 IU", 18.0, 20, "Vitamin E" },
                    { 21, "Bone Health", "Solgar", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2915), "Solgar Vitamin K2 45mcg supports bone and heart health.", "Vitamin K2 45mcg", 20.0, 15, "Vitamin K" },
                    { 22, "Digestive Health", "Garden of Life", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2917), "Garden of Life Digestive Enzymes support healthy digestion.", "Digestive Enzymes", 22.0, 25, "Digestive Enzymes" },
                    { 23, "Beauty", "Garden of Life", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2919), "Garden of Life Collagen Peptides Powder supports healthy skin, hair, nails, and joints.", "Collagen Peptides Powder", 45.0, 20, "Collagen" },
                    { 24, "Overall Health", "Garden of Life", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2920), "Garden of Life Men's Multivitamin supports overall men's health.", "Men's Multivitamin", 30.0, 35, "Multivitamins" },
                    { 25, "Joint Health", "Garden of Life", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2922), "Garden of Life Turmeric 500mg supports joint health and inflammatory response.", "Turmeric 500mg", 28.0, 18, "Turmeric" },
                    { 26, "Immune System", "Garden of Life", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2924), "Garden of Life Vitamin C 1000mg supports immune system health.", "Vitamin C 1000mg", 20.0, 30, "Vitamin C" },
                    { 27, "Heart Health", "Spring Valley", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2926), "Spring Valley Fish Oil 1000mg supports heart and brain health.", "Fish Oil 1000mg", 28.0, 20, "Fish Oil" },
                    { 28, "Digestive Health", "Spring Valley", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2927), "Spring Valley Probiotic 50 Billion CFU supports digestive and immune health.", "Probiotic 50 Billion CFU", 40.0, 25, "Probiotics" },
                    { 29, "Immune System", "Nature's Way", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2931), "Nature's Way Elderberry Gummies support immune system health.", "Elderberry Gummies", 25.0, 30, "Elderberry" },
                    { 30, "Stress Relief", "Nature's Way", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2933), "Nature's Way Ashwagandha 500mg supports stress relief and energy.", "Ashwagandha 500mg", 20.0, 20, "Herbal" },
                    { 31, "Bone Health", "Nature's Way", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2935), "Nature's Way Vitamin D3 2000 IU supports bone and immune health.", "Vitamin D3 2000 IU", 18.0, 22, "Vitamin D" },
                    { 32, "Joint Health", "Nature's Way", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2972), "Nature's Way Turmeric Curcumin 1000mg supports joint health and inflammatory response.", "Turmeric Curcumin 1000mg", 30.0, 18, "Turmeric" },
                    { 33, "Brain Health", "Nature's Way", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2973), "Nature's Way Ginkgo Biloba 120mg supports brain function and mental alertness.", "Ginkgo Biloba 120mg", 22.0, 15, "Herbal" },
                    { 34, "Digestive Health", "Lake Avenue", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2975), "Lake Avenue Probiotic 25 Billion CFU supports digestive health and immune function.", "Probiotic 25 Billion CFU", 35.0, 25, "Probiotics" },
                    { 35, "Immune System", "Nature's Bounty", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2977), "Nature's Bounty Vitamin C with Rose Hips 1000mg supports immune system health.", "Vitamin C with Rose Hips 1000mg", 15.0, 30, "Vitamin C" },
                    { 36, "Immune System", "Nature's Bounty", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2979), "Nature's Bounty Zinc 50mg supports immune system health.", "Zinc 50mg", 12.0, 20, "Zinc" },
                    { 37, "Energy", "Nature's Bounty", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2981), "Nature's Bounty Vitamin B12 1000mcg supports energy metabolism and nervous system health.", "Vitamin B12 1000mcg", 18.0, 22, "Vitamin B" },
                    { 38, "Overall Health", "Nature's Bounty", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2983), "Nature's Bounty Iron 65mg supports red blood cell production and energy metabolism.", "Iron 65mg", 10.0, 20, "Iron" },
                    { 39, "Bone Health", "Citracal", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2985), "Citracal Calcium Citrate 600mg supports bone health and muscle function.", "Calcium Citrate 600mg", 25.0, 20, "Calcium" },
                    { 40, "Immune System", "Sambucol", new DateTime(2024, 7, 31, 17, 41, 59, 465, DateTimeKind.Local).AddTicks(2987), "Sambucol Elderberry Syrup supports immune system health with high antioxidant levels.", "Elderberry Syrup", 20.0, 15, "Elderberry" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "ImagePath", "ItemID" },
                values: new object[,]
                {
                    { 1, "fish_oil.png", 1 },
                    { 2, "eye_lutein.png", 2 },
                    { 3, "vitamin_c.png", 3 },
                    { 4, "product4.jpg", 4 },
                    { 5, "product5.jpg", 5 },
                    { 6, "product6.jpg", 6 },
                    { 7, "product7.jpg", 7 },
                    { 8, "product8.jpg", 8 },
                    { 9, "product9.jpg", 9 },
                    { 10, "product10.jpg", 10 },
                    { 11, "product11.jpg", 11 },
                    { 12, "product12.jpg", 12 },
                    { 13, "product13.jpg", 13 },
                    { 14, "product14.jpg", 14 },
                    { 15, "product15.jpg", 15 },
                    { 16, "product16.jpg", 16 },
                    { 17, "product17.jpg", 17 },
                    { 18, "product18.jpg", 18 },
                    { 19, "product19.jpg", 19 },
                    { 20, "product20.jpg", 20 },
                    { 21, "product21.jpg", 21 },
                    { 22, "product22.jpg", 22 },
                    { 23, "product23.jpg", 23 },
                    { 24, "product24.jpg", 24 },
                    { 25, "product25.jpg", 25 },
                    { 26, "product26.jpg", 26 },
                    { 27, "product27.jpg", 27 },
                    { 28, "product28.jpg", 28 },
                    { 29, "product29.jpg", 29 },
                    { 30, "product30.jpg", 30 },
                    { 31, "product31.jpg", 31 },
                    { 32, "product32.jpg", 32 },
                    { 33, "product33.jpg", 33 },
                    { 34, "product34.jpg", 34 },
                    { 35, "product35.jpg", 35 },
                    { 36, "product36.jpg", 36 },
                    { 37, "product37.jpg", 37 },
                    { 38, "product38.jpg", 38 },
                    { 39, "product39.jpg", 39 },
                    { 40, "product40.jpg", 40 }
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
                name: "IX_Images_ItemID",
                table: "Images",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemID",
                table: "OrderItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");
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
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
