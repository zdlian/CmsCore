using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCore.Data.Migrations
{
    public partial class linkCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkCategory_LinkCategory_ParentCategoryId",
                table: "LinkCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkLinkCategory_LinkCategory_LinkCategoryId",
                table: "LinkLinkCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkCategory",
                table: "LinkCategory");

            migrationBuilder.RenameTable(
                name: "LinkCategory",
                newName: "LinkCategories");

            migrationBuilder.RenameIndex(
                name: "IX_LinkCategory_ParentCategoryId",
                table: "LinkCategories",
                newName: "IX_LinkCategories_ParentCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "LinkCategories",
                maxLength: 200,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LinkCategories",
                maxLength: 200,
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkCategories",
                table: "LinkCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkCategories_LinkCategories_ParentCategoryId",
                table: "LinkCategories",
                column: "ParentCategoryId",
                principalTable: "LinkCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkLinkCategory_LinkCategories_LinkCategoryId",
                table: "LinkLinkCategory",
                column: "LinkCategoryId",
                principalTable: "LinkCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkCategories_LinkCategories_ParentCategoryId",
                table: "LinkCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkLinkCategory_LinkCategories_LinkCategoryId",
                table: "LinkLinkCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkCategories",
                table: "LinkCategories");

            migrationBuilder.RenameTable(
                name: "LinkCategories",
                newName: "LinkCategory");

            migrationBuilder.RenameIndex(
                name: "IX_LinkCategories_ParentCategoryId",
                table: "LinkCategory",
                newName: "IX_LinkCategory_ParentCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "LinkCategory",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LinkCategory",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkCategory",
                table: "LinkCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkCategory_LinkCategory_ParentCategoryId",
                table: "LinkCategory",
                column: "ParentCategoryId",
                principalTable: "LinkCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkLinkCategory_LinkCategory_LinkCategoryId",
                table: "LinkLinkCategory",
                column: "LinkCategoryId",
                principalTable: "LinkCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
