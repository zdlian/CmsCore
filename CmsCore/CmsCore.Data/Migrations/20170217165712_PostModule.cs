using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCore.Data.Migrations
{
    public partial class PostModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostPostCategories_Post_PostId",
                table: "PostPostCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostPostCategories_Posts_PostId",
                table: "PostPostCategories",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostPostCategories_Posts_PostId",
                table: "PostPostCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Post",
                maxLength: 250,
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostPostCategories_Post_PostId",
                table: "PostPostCategories",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
