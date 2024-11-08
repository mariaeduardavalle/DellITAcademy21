using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuProjetoMigration.Migrations
{
    /// <inheritdoc />
    public partial class BlogEstendidov2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "blogIdId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTimeStamp",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_blogIdId",
                table: "Posts",
                column: "blogIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_blogIdId",
                table: "Posts",
                column: "blogIdId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_blogIdId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_blogIdId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "blogIdId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedTimeStamp",
                table: "Blogs");
        }
    }
}
