using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuProjetoMigration.Migrations
{
    /// <inheritdoc />
    public partial class BlogEstendidov3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_blogIdId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "blogIdId",
                table: "Posts",
                newName: "blogId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_blogIdId",
                table: "Posts",
                newName: "IX_Posts_blogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_blogId",
                table: "Posts",
                column: "blogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_blogId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "blogId",
                table: "Posts",
                newName: "blogIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_blogId",
                table: "Posts",
                newName: "IX_Posts_blogIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_blogIdId",
                table: "Posts",
                column: "blogIdId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
