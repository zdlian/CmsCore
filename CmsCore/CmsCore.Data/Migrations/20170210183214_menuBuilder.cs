using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCore.Data.Migrations
{
    public partial class menuBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuLocations_Menus_MenuId",
                table: "MenuLocations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Menus_MenuLocationId",
                table: "Menus");

            migrationBuilder.AlterColumn<long>(
                name: "MenuLocationId",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuLocations_Menus_MenuId",
                table: "MenuLocations",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuLocations_Menus_MenuId",
                table: "MenuLocations");

            migrationBuilder.AlterColumn<long>(
                name: "MenuLocationId",
                table: "Menus",
                nullable: false);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Menus_MenuLocationId",
                table: "Menus",
                column: "MenuLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuLocations_Menus_MenuId",
                table: "MenuLocations",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuLocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
