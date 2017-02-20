using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CmsCore.Model.Entities;
using CmsCore.Model.EntityBuilders;

namespace CmsCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuLocation> MenuLocations { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostPostCategory> PostPostCategories { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateSection> TemplatSections { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Setting> Settings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            new MenuBuilder(builder.Entity<Menu>());
            new MenuLocationBuilder(builder.Entity<MenuLocation>());
            new PageBuilder(builder.Entity<Page>());
            new TemplateBuilder(builder.Entity<Template>());
            new PostBuilder(builder.Entity<Post>());
            new SettingBuilder(builder.Entity<Setting>());
            new PostCategoryBuilder(builder.Entity<PostCategory>());
            new PostPostCategoryBuilder(builder.Entity<PostPostCategory>());
            new TemplateSectionBuilder(builder.Entity<TemplateSection>());
            
        }
    }
}
