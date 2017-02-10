using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CmsCore.Data.Migrations
{
    public partial class builderUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_MenuLocations_MenuLocationId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuLocations_Menus_MenuId",
                table: "MenuLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Template_TemplateId1",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_TemplateId1",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_MenuLocations_MenuId",
                table: "MenuLocations");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuLocationId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "TemplateId1",
                table: "Pages");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Pages",
                maxLength: 200,
                nullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "TemplateId",
                table: "Pages",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Pages",
                maxLength: 200,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "SeoTitle",
                table: "Pages",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                maxLength: 200,
                nullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "MenuLocationId",
                table: "Menus",
                nullable: false);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Menus_MenuLocationId",
                table: "Menus",
                column: "MenuLocationId");

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

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Body = table.Column<string>(maxLength: 250, nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 200, nullable: true),
                    Slug = table.Column<string>(maxLength: 200, nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Value = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategories_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategories_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_TemplateId",
                table: "Pages",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuLocations_MenuId",
                table: "MenuLocations",
                column: "MenuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuLocations_Menus_MenuId",
                table: "MenuLocations",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuLocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Template_TemplateId",
                table: "Pages",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuLocations_Menus_MenuId",
                table: "MenuLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Template_TemplateId",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Pages_TemplateId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_MenuLocations_MenuId",
                table: "MenuLocations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Menus_MenuLocationId",
                table: "Menus");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Pages",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TemplateId",
                table: "Pages",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Pages",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SeoTitle",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TemplateId1",
                table: "Pages",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MenuLocationId",
                table: "Menus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_TemplateId1",
                table: "Pages",
                column: "TemplateId1");

            migrationBuilder.CreateIndex(
                name: "IX_MenuLocations_MenuId",
                table: "MenuLocations",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuLocationId",
                table: "Menus",
                column: "MenuLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_MenuLocations_MenuLocationId",
                table: "Menus",
                column: "MenuLocationId",
                principalTable: "MenuLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuLocations_Menus_MenuId",
                table: "MenuLocations",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Template_TemplateId1",
                table: "Pages",
                column: "TemplateId1",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
