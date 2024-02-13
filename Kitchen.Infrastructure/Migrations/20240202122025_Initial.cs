using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitchen.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_FoodCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId");

            var userId = "c5cd6ea8-802e-40d5-90a6-cd6289e9ab0f";
            var insertUserSqlCommand = $@"
                insert into ""Users""
                    (""Id"",
                    ""Name"",
                    ""Email"",
                    ""Password"",
                    ""CreationDate"")
                values
                    ('{userId}'::uuid,
                    'appuser',
                    'appuser@example.com',
                    '$2a$11$ATvNPWVgKCcVUnpfBMXlmuU8D4vm3cCZ5hjNTLuvlhezHMg/5MTEK', -- appuser
                    '2024-01-23 22:10:15.844 +0300');";

            migrationBuilder.Sql(insertUserSqlCommand);

            var projectId = "10bbcb46-5e20-424b-b424-ca67dbf989ff";
            var insertProjectSqlCommand = $@"
                insert into ""Projects""
	                (""Id"",
	                ""CreationDate"",
	                ""Name"",
	                ""Description"")
                values
	                ('{projectId}',
	                '2024-01-21 19:41:40.734 +0300',
	                'Тестовый проект-Х',
	                'Это тестовый проект, для демонстрации наполненности веб приложения');";

            migrationBuilder.Sql(insertProjectSqlCommand);

            var foodCategoryAId = "b621e6bd-553c-4d44-a815-cbfd13830908";
            var foodCategoryBId = "093bdbc7-fde8-4f1c-8153-2835710fda4e";
            var foodCategoryCId = "748e7cec-0539-40f7-9e35-6ba091648fa3";
            var insertFoodCategorySqlCommand = $@"
                insert into ""FoodCategories""
	                (""Id"",
	                ""CreationDate"",
	                ""Name"",
	                ""Description"",
                    ""ProjectId"") 
                values
	                ('{foodCategoryAId}',
	                '2024-01-21 19:41:10.162 +0300',
	                'Бургеры',
	                'Топовые бургеры и их разновидности.',
                    '{projectId}'),
	
	                ('{foodCategoryBId}',
	                '2024-01-21 19:41:20.162 +0300',
	                'Десерты',
	                'Сладкие десерты разных сортов',
                    '{projectId}'),

                    ('{foodCategoryCId}',
	                '2024-01-21 19:41:30.162 +0300',
	                'Напитки',
	                'Горячие и холодные, вкусные и простые',
                    '{projectId}')";

            migrationBuilder.Sql(insertFoodCategorySqlCommand);

            var insertFoodSqlCommand = $@"
				insert into ""Foods""
					(""Id"",
					""CreationDate"",
					""LastUpdateDate"",
					""Name"",
					""Description"",
					""Price"",
					""CategoryId"",
					""ProjectId"")
				values
					('19642039-c08a-42ca-8cc3-a1c3741d595c',
					'2024-01-21 19:42:30.390 +0300',
					'2024-01-21 19:43:30.390 +0300',
					'Простой Бургер',
					'Да, это простой бургер',
					'147',
					'{foodCategoryAId}',
					'{projectId}'),
	
					('4dbee801-968d-40ac-af65-b8b91fac1821',
					'2024-01-21 19:42:30.390 +0300',
					'2024-01-21 19:43:30.390 +0300',
					'Сложный Бургер',
					'Вот это уже интересно',
					'247',
					'{foodCategoryAId}',
					'{projectId}'),

					('1fe20fca-a00b-4711-b108-c0221681ba43',
					'2024-01-21 19:42:30.390 +0300',
					'2024-01-21 19:43:30.390 +0300',
					'Какая то пицца',
					'Действительно',
					'147',
					'{foodCategoryBId}',
					'{projectId}'),
	
					('3b7850ba-d7fa-49c4-9bf9-d770f0239ea4',
					'2024-01-21 19:42:30.390 +0300',
					'2024-01-21 19:43:30.390 +0300',
					'Водичка',
					'Из колодца',
					'147',
					'{foodCategoryCId}',
					'{projectId}');";

            migrationBuilder.Sql(insertFoodSqlCommand);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodPrices");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FoodCategories");
        }
    }
}
