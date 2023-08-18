using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListDemo.Server.Data.Migrations
{
    public partial class AddUserIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "ShoppingItems");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "ItemImages");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ItemImages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_UserId",
                table: "ShoppingItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_UserId",
                table: "ItemImages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImages_AspNetUsers_UserId",
                table: "ItemImages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_AspNetUsers_UserId",
                table: "ShoppingItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_UserId",
                table: "ShoppingLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemImages_AspNetUsers_UserId",
                table: "ItemImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_AspNetUsers_UserId",
                table: "ShoppingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingItems_UserId",
                table: "ShoppingItems");

            migrationBuilder.DropIndex(
                name: "IX_ItemImages_UserId",
                table: "ItemImages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItemImages");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "ShoppingLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "ShoppingItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "ItemImages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
