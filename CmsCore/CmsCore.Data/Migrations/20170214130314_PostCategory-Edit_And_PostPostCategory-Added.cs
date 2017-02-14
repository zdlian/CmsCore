using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CmsCore.Data.Migrations
{
    public partial class PostCategoryEdit_And_PostPostCategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_Category_CategoryId",
                table: "PostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_Post_PostId",
                table: "PostCategories");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories");

            migrationBuilder.DropIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostCategories");
            

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PostCategories",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "PostCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "PostCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PostCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PostCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "PostCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PostCategories",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ParentCategoryId",
                table: "PostCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "PostCategories",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PostPostCategories",
                columns: table => new
                {
                    PostId = table.Column<long>(nullable: false),
                    PostCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPostCategories", x => new { x.PostId, x.PostCategoryId });
                    table.ForeignKey(
                        name: "FK_PostPostCategories_PostCategories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostPostCategories_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_ParentCategoryId",
                table: "PostCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPostCategories_PostCategoryId",
                table: "PostPostCategories",
                column: "PostCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_PostCategories_ParentCategoryId",
                table: "PostCategories",
                column: "ParentCategoryId",
                principalTable: "PostCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_PostCategories_ParentCategoryId",
                table: "PostCategories");

            migrationBuilder.DropTable(
                name: "PostPostCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories");

            migrationBuilder.DropIndex(
                name: "IX_PostCategories_ParentCategoryId",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "PostCategories");

            migrationBuilder.AddColumn<long>(
                name: "PostId",
                table: "PostCategories",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "PostCategories",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories",
                columns: new[] { "PostId", "CategoryId" });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentCategoryId = table.Column<long>(nullable: true),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_Category_CategoryId",
                table: "PostCategories",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_Post_PostId",
                table: "PostCategories",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
