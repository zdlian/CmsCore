using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CmsCore.Data.Migrations
{
    public partial class products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplatSections_Sections_SectionId",
                table: "TemplatSections");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplatSections_Templates_TemplateId",
                table: "TemplatSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplatSections",
                table: "TemplatSections");

            migrationBuilder.RenameTable(
                name: "TemplatSections",
                newName: "TemplateSections");

            migrationBuilder.RenameIndex(
                name: "IX_TemplatSections_SectionId",
                table: "TemplateSections",
                newName: "IX_TemplateSections_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateSections",
                table: "TemplateSections",
                columns: new[] { "TemplateId", "SectionId" });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    OldPrice = table.Column<decimal>(nullable: false),
                    ParentProductId = table.Column<long>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ViewCount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentProductId",
                        column: x => x.ParentProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
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
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_ProductCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    ProductCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductCategory", x => new { x.ProductId, x.ProductCategoryId });
                    table.ForeignKey(
                        name: "FK_ProductProductCategory_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentProductId",
                table: "Products",
                column: "ParentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ParentCategoryId",
                table: "ProductCategory",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductCategory_ProductCategoryId",
                table: "ProductProductCategory",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateSections_Sections_SectionId",
                table: "TemplateSections",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateSections_Templates_TemplateId",
                table: "TemplateSections",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateSections_Sections_SectionId",
                table: "TemplateSections");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateSections_Templates_TemplateId",
                table: "TemplateSections");

            migrationBuilder.DropTable(
                name: "ProductProductCategory");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateSections",
                table: "TemplateSections");

            migrationBuilder.RenameTable(
                name: "TemplateSections",
                newName: "TemplatSections");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateSections_SectionId",
                table: "TemplatSections",
                newName: "IX_TemplatSections_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplatSections",
                table: "TemplatSections",
                columns: new[] { "TemplateId", "SectionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TemplatSections_Sections_SectionId",
                table: "TemplatSections",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplatSections_Templates_TemplateId",
                table: "TemplatSections",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
