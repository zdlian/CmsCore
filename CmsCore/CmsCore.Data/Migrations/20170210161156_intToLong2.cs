using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCore.Data.Migrations
{
    public partial class intToLong2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MenuLocations_MenuId",
                table: "MenuLocations");

            migrationBuilder.AlterColumn<long>(
                name: "MenuLocationId",
                table: "Menus",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_MenuLocations_MenuLocationId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_MenuLocations_MenuId",
                table: "MenuLocations");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuLocationId",
                table: "Menus");

            migrationBuilder.AlterColumn<int>(
                name: "MenuLocationId",
                table: "Menus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuLocations_MenuId",
                table: "MenuLocations",
                column: "MenuId",
                unique: true);
        }
    }
}
