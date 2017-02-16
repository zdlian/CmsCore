using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCore.Data.Migrations
{
    public partial class manytomanyTemplateSideBar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SideBars_Templates_TemplateId",
                table: "SideBars");

            migrationBuilder.DropIndex(
                name: "IX_SideBars_TemplateId",
                table: "SideBars");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "SideBars");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateSideBars");

            migrationBuilder.AddColumn<long>(
                name: "TemplateId",
                table: "SideBars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SideBars_TemplateId",
                table: "SideBars",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_SideBars_Templates_TemplateId",
                table: "SideBars",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
