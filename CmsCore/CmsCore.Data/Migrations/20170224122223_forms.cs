using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CmsCore.Data.Migrations
{
    public partial class forms : Migration
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
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ClosingDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmailBcc = table.Column<string>(nullable: true),
                    EmailCc = table.Column<string>(nullable: true),
                    EmailTo = table.Column<string>(nullable: true),
                    FormName = table.Column<string>(nullable: true),
                    GoogleAnalyticsCode = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFields",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    FieldType = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: true),
                    FormId1 = table.Column<long>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormFields_Forms_FormId1",
                        column: x => x.FormId1,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_FormId1",
                table: "FormFields",
                column: "FormId1");

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
                name: "FormFields");

            migrationBuilder.DropTable(
                name: "Forms");

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
