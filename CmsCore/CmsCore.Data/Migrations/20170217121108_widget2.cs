using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CmsCore.Data.Migrations
{
    public partial class widget2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Widgets_SideBars_SideBarId1",
                table: "Widgets");

            migrationBuilder.DropTable(
                name: "TemplateSideBars");

            migrationBuilder.DropTable(
                name: "SideBars");

            migrationBuilder.RenameColumn(
                name: "SideBarId1",
                table: "Widgets",
                newName: "SectionId1");

            migrationBuilder.RenameColumn(
                name: "SideBarId",
                table: "Widgets",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Widgets_SideBarId1",
                table: "Widgets",
                newName: "IX_Widgets_SectionId1");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplatSections",
                columns: table => new
                {
                    TemplateId = table.Column<long>(nullable: false),
                    SectionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplatSections", x => new { x.TemplateId, x.SectionId });
                    table.ForeignKey(
                        name: "FK_TemplatSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplatSections_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplatSections_SectionId",
                table: "TemplatSections",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_Sections_SectionId1",
                table: "Widgets",
                column: "SectionId1",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Widgets_Sections_SectionId1",
                table: "Widgets");

            migrationBuilder.DropTable(
                name: "TemplatSections");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.RenameColumn(
                name: "SectionId1",
                table: "Widgets",
                newName: "SideBarId1");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Widgets",
                newName: "SideBarId");

            migrationBuilder.RenameIndex(
                name: "IX_Widgets_SectionId1",
                table: "Widgets",
                newName: "IX_Widgets_SideBarId1");

            migrationBuilder.CreateTable(
                name: "SideBars",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideBars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateSideBars",
                columns: table => new
                {
                    TemplateId = table.Column<long>(nullable: false),
                    SideBarId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateSideBars", x => new { x.TemplateId, x.SideBarId });
                    table.ForeignKey(
                        name: "FK_TemplateSideBars_SideBars_SideBarId",
                        column: x => x.SideBarId,
                        principalTable: "SideBars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateSideBars_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateSideBars_SideBarId",
                table: "TemplateSideBars",
                column: "SideBarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_SideBars_SideBarId1",
                table: "Widgets",
                column: "SideBarId1",
                principalTable: "SideBars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
