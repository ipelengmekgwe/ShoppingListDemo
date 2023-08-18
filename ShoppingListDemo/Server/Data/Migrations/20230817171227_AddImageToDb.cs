using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListDemo.Server.Data.Migrations
{
    public partial class AddImageToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ItemImages",
                newName: "ContentType");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "ItemImages",
                type: "image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ItemImages");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "ItemImages",
                newName: "ImageUrl");
        }
    }
}
