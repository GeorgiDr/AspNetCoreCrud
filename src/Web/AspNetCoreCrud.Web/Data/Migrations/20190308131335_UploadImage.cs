using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreCrud.Web.Data.Migrations
{
    public partial class UploadImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Album",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Album");
        }
    }
}
