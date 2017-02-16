using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCore.Data.Migrations
{
    public partial class PageTemplateIdIsOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Template_TemplateId",
                table: "Pages");

            migrationBuilder.AlterColumn<long>(
                name: "TemplateId",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Template_TemplateId",
                table: "Pages",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Template_TemplateId",
                table: "Pages");

            migrationBuilder.AlterColumn<long>(
                name: "TemplateId",
                table: "Pages",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Template_TemplateId",
                table: "Pages",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
