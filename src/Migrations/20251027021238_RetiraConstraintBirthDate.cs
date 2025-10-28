using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugStore.Migrations
{
    /// <inheritdoc />
    public partial class RetiraConstraintBirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId1",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ProductId1",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "OrderLines");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Customers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines");

            migrationBuilder.AddColumn<string>(
                name: "ProductId1",
                table: "OrderLines",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId1",
                table: "OrderLines",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId1",
                table: "OrderLines",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
