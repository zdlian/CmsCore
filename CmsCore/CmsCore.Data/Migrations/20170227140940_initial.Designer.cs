using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CmsCore.Data;
using CmsCore.Model.Entities;

namespace CmsCore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170227140940_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CmsCore.Model.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Form", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ClosingDescription");

                    b.Property<string>("Description");

                    b.Property<string>("EmailBcc");

                    b.Property<string>("EmailCc");

                    b.Property<string>("EmailTo");

                    b.Property<long?>("FormId");

                    b.Property<string>("FormName");

                    b.Property<string>("GoogleAnalyticsCode");

                    b.Property<bool>("IsPublished");

                    b.Property<long>("LanguageId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.FormField", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("FieldType");

                    b.Property<int?>("FormId");

                    b.Property<long?>("FormId1");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int>("Position");

                    b.Property<bool>("Required");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("FormId1");

                    b.ToTable("FormFields");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Language", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Culture");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("NativeName");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Link", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsVisible");

                    b.Property<long>("LanguageId");

                    b.Property<long?>("LinkId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Target");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("LinkId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.LinkCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<long>("LanguageId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("ParentCategoryId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("LinkCategories");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.LinkLinkCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<long>("LinkCategoryId");

                    b.Property<long>("LinkId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("LinkCategoryId");

                    b.HasIndex("LinkId");

                    b.ToTable("LinkLinkCategory");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<string>("FileName");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("Size");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<long>("LanguageId");

                    b.Property<long?>("MenuLocationId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.MenuItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<long?>("MenuId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<long?>("ParentMenuItemId");

                    b.Property<string>("Target");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("ParentMenuItemId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.MenuLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<long?>("MenuId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MenuId")
                        .IsUnique();

                    b.ToTable("MenuLocations");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Page", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Body");

                    b.Property<bool>("IsPublished");

                    b.Property<long>("LanguageId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<long?>("PageId");

                    b.Property<long?>("ParentPageId");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoTitle")
                        .HasMaxLength(200);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("TemplateId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PageId");

                    b.HasIndex("ParentPageId");

                    b.HasIndex("TemplateId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Body");

                    b.Property<bool>("IsPublished");

                    b.Property<long>("LanguageId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<long?>("PostId");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoTitle")
                        .HasMaxLength(200);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PostId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.PostCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<long>("LanguageId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("ParentCategoryId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.PostPostCategory", b =>
                {
                    b.Property<long>("PostId");

                    b.Property<long>("PostCategoryId");

                    b.HasKey("PostId", "PostCategoryId");

                    b.HasIndex("PostCategoryId");

                    b.ToTable("PostPostCategories");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Body");

                    b.Property<string>("Code");

                    b.Property<bool>("IsAvailable");

                    b.Property<bool>("IsNew");

                    b.Property<bool>("IsPublished");

                    b.Property<long>("LanguageId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("OldPrice");

                    b.Property<long?>("ParentProductId");

                    b.Property<string>("Photo");

                    b.Property<decimal>("Price");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoTitle");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.Property<long>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ParentProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.ProductCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<long>("LanguageId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<long?>("ParentCategoryId");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.ProductProductCategory", b =>
                {
                    b.Property<long>("ProductId");

                    b.Property<long>("ProductCategoryId");

                    b.HasKey("ProductId", "ProductCategoryId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductProductCategory");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Redirect", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NewUrl")
                        .HasMaxLength(200);

                    b.Property<string>("OldUrl")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Redirects");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Section", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Setting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Template", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ViewName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.TemplateSection", b =>
                {
                    b.Property<long>("TemplateId");

                    b.Property<long>("SectionId");

                    b.HasKey("TemplateId", "SectionId");

                    b.HasIndex("SectionId");

                    b.ToTable("TemplateSections");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Widget", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsTemplate");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Params");

                    b.Property<int?>("SectionId");

                    b.Property<long?>("SectionId1");

                    b.HasKey("Id");

                    b.HasIndex("SectionId1");

                    b.ToTable("Widgets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Form", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Form")
                        .WithMany("Translations")
                        .HasForeignKey("FormId");

                    b.HasOne("CmsCore.Model.Entities.Language", "Language")
                        .WithMany("Forms")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCore.Model.Entities.FormField", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Form", "Form")
                        .WithMany("FormFields")
                        .HasForeignKey("FormId1");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Link", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Language", "Language")
                        .WithMany("Links")
                        .HasForeignKey("LanguageId");

                    b.HasOne("CmsCore.Model.Entities.Link")
                        .WithMany("Translations")
                        .HasForeignKey("LinkId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.LinkCategory", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Language", "Language")
                        .WithMany("LinkCategories")
                        .HasForeignKey("LanguageId");

                    b.HasOne("CmsCore.Model.Entities.LinkCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.LinkLinkCategory", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.LinkCategory", "LinkCategory")
                        .WithMany("LinkLinkCategories")
                        .HasForeignKey("LinkCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCore.Model.Entities.Link", "Link")
                        .WithMany("LinkLinkCategories")
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Menu", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Language", "Language")
                        .WithMany("Menus")
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.MenuItem", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Menu", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId");

                    b.HasOne("CmsCore.Model.Entities.MenuItem", "ParentMenuItem")
                        .WithMany("ChildMenuItems")
                        .HasForeignKey("ParentMenuItemId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.MenuLocation", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Menu", "Menu")
                        .WithOne("MenuLocation")
                        .HasForeignKey("CmsCore.Model.Entities.MenuLocation", "MenuId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Page", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Language", "Language")
                        .WithMany("Pages")
                        .HasForeignKey("LanguageId");

                    b.HasOne("CmsCore.Model.Entities.Page")
                        .WithMany("Translations")
                        .HasForeignKey("PageId");

                    b.HasOne("CmsCore.Model.Entities.Page", "ParentPage")
                        .WithMany("ChildPages")
                        .HasForeignKey("ParentPageId");

                    b.HasOne("CmsCore.Model.Entities.Template", "Template")
                        .WithMany("Pages")
                        .HasForeignKey("TemplateId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Post", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Language", "Language")
                        .WithMany("Posts")
                        .HasForeignKey("LanguageId");

                    b.HasOne("CmsCore.Model.Entities.Post")
                        .WithMany("Translations")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.PostCategory", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Language", "Language")
                        .WithMany("PostCategories")
                        .HasForeignKey("LanguageId");

                    b.HasOne("CmsCore.Model.Entities.PostCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.PostPostCategory", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.PostCategory", "PostCategory")
                        .WithMany("PostPostCategories")
                        .HasForeignKey("PostCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCore.Model.Entities.Post", "Post")
                        .WithMany("PostPostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Product", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Language", "Language")
                        .WithMany("Products")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCore.Model.Entities.Product", "ParentProduct")
                        .WithMany("ChildProducts")
                        .HasForeignKey("ParentProductId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.ProductCategory", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Language", "Language")
                        .WithMany("ProductCategories")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCore.Model.Entities.ProductCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.ProductProductCategory", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.ProductCategory", "ProductCategory")
                        .WithMany("ProductProductCategories")
                        .HasForeignKey("ProductCategoryId");

                    b.HasOne("CmsCore.Model.Entities.Product", "Product")
                        .WithMany("ProductProductCategories")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("CmsCore.Model.Entities.TemplateSection", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Section", "Section")
                        .WithMany("TemplateSections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCore.Model.Entities.Template", "Template")
                        .WithMany("TemplateSections")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCore.Model.Entities.Widget", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.Section", "Section")
                        .WithMany("Widgets")
                        .HasForeignKey("SectionId1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CmsCore.Model.Entities.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCore.Model.Entities.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
