using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitchen.Infrastructure.Migrations
{
    public partial class FillFoodPriceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var insertFoodPricesSqlCommand = $@"
                insert into ""FoodPrices""
                    (""Id"",
                    ""CreationDate"",
                    ""FoodId"",
                    ""Price"")
                values
                    ('0b9ce942-67ce-43aa-b9f7-4a0188b91bf9'::uuid,
                    '2024-01-21 19:42:30.390 +0300',
                    '19642039-c08a-42ca-8cc3-a1c3741d595c'::uuid,
                    '147'),

                    ('3c17f355-96cd-40fd-a5ed-54d95fc97e9b'::uuid,
                    '2024-01-21 19:42:30.390 +0300',
                    '4dbee801-968d-40ac-af65-b8b91fac1821'::uuid,
                    '247'),

                    ('3521680f-1fec-462a-a145-910368407ea1'::uuid,
                    '2024-01-21 19:42:30.390 +0300',
                    '1fe20fca-a00b-4711-b108-c0221681ba43'::uuid,
                    '147'),

                    ('f4cee48f-7864-4038-83d1-182f9440d7a6'::uuid,
                    '2024-01-21 19:42:30.390 +0300',
                    '3b7850ba-d7fa-49c4-9bf9-d770f0239ea4'::uuid,
                    '147');";

            migrationBuilder.Sql(insertFoodPricesSqlCommand);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
