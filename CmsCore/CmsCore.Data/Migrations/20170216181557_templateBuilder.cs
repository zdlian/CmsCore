using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCore.Data.Migrations
{
    public partial class templateBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ViewName",
                table: "Templates",
                maxLength: 200,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Templates",
                maxLength: 200,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ViewName",
                table: "Templates",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Templates",
                nullable: true);
        }
    }
}
