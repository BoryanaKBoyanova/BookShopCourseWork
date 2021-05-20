using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShopCourseWork.Migrations
{
    public partial class FixedOrderModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookQuantity_Orders_OrderId",
                table: "BookQuantity");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "BookQuantity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookQuantity_Orders_OrderId",
                table: "BookQuantity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookQuantity_Orders_OrderId",
                table: "BookQuantity");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "BookQuantity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookQuantity_Orders_OrderId",
                table: "BookQuantity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
