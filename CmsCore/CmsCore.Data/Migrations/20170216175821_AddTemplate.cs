using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCore.Data.Migrations
{
    public partial class AddTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Template_TemplateId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_SideBar_Template_TemplateId",
                table: "SideBar");

            migrationBuilder.DropForeignKey(
                name: "FK_Widget_SideBar_SideBarId1",
                table: "Widget");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Widget",
                table: "Widget");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Template",
                table: "Template");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SideBar",
                table: "SideBar");

            migrationBuilder.RenameTable(
                name: "Widget",
                newName: "Widgets");

            migrationBuilder.RenameTable(
                name: "Template",
                newName: "Templates");

            migrationBuilder.RenameTable(
                name: "SideBar",
                newName: "SideBars");

            migrationBuilder.RenameIndex(
                name: "IX_Widget_SideBarId1",
                table: "Widgets",
                newName: "IX_Widgets_SideBarId1");

            migrationBuilder.RenameIndex(
                name: "IX_SideBar_TemplateId",
                table: "SideBars",
                newName: "IX_SideBars_TemplateId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Widgets",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MenuId",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Widgets",
                table: "Widgets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Templates",
                table: "Templates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SideBars",
                table: "SideBars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Templates_TemplateId",
                table: "Pages",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SideBars_Templates_TemplateId",
                table: "SideBars",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_SideBars_SideBarId1",
                table: "Widgets",
                column: "SideBarId1",
                principalTable: "SideBars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Templates_TemplateId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_SideBars_Templates_TemplateId",
                table: "SideBars");

            migrationBuilder.DropForeignKey(
                name: "FK_Widgets_SideBars_SideBarId1",
                table: "Widgets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Widgets",
                table: "Widgets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Templates",
                table: "Templates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SideBars",
                table: "SideBars");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Widgets");

            migrationBuilder.RenameTable(
                name: "Widgets",
                newName: "Widget");

            migrationBuilder.RenameTable(
                name: "Templates",
                newName: "Template");

            migrationBuilder.RenameTable(
                name: "SideBars",
                newName: "SideBar");

            migrationBuilder.RenameIndex(
                name: "IX_Widgets_SideBarId1",
                table: "Widget",
                newName: "IX_Widget_SideBarId1");

            migrationBuilder.RenameIndex(
                name: "IX_SideBars_TemplateId",
                table: "SideBar",
                newName: "IX_SideBar_TemplateId");

            migrationBuilder.AlterColumn<long>(
                name: "MenuId",
                table: "MenuItems",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Widget",
                table: "Widget",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Template",
                table: "Template",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SideBar",
                table: "SideBar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Template_TemplateId",
                table: "Pages",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SideBar_Template_TemplateId",
                table: "SideBar",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Widget_SideBar_SideBarId1",
                table: "Widget",
                column: "SideBarId1",
                principalTable: "SideBar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
