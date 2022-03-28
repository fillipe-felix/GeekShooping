using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShooping.CouponAPI.Migrations
{
    public partial class SeedCouponDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "id", "coupon_code", "discount_amount" },
                values: new object[] { new Guid("50ebf12c-8885-4bab-928d-bae0da212fbc"), "ERUDIO_2022_15", 15m });

            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "id", "coupon_code", "discount_amount" },
                values: new object[] { new Guid("f6404a7b-6fe6-448f-a3fd-994ad9f0332b"), "ERUDIO_2022_10", 10m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "id",
                keyValue: new Guid("50ebf12c-8885-4bab-928d-bae0da212fbc"));

            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "id",
                keyValue: new Guid("f6404a7b-6fe6-448f-a3fd-994ad9f0332b"));
        }
    }
}
