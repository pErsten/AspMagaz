using Microsoft.EntityFrameworkCore.Migrations;

namespace AspMagaz.Migrations
{
    public partial class _4_Migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photoes_Products_ProductId",
                table: "Photoes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Photoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "Photoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Photoes_Products_ProductId",
                table: "Photoes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photoes_Products_ProductId",
                table: "Photoes");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "Photoes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Photoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Photoes_Products_ProductId",
                table: "Photoes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
