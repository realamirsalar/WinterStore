using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixBasketItemProductRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId",
                unique: true);
        }
    }
}
