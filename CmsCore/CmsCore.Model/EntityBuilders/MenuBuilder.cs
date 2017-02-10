using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CmsCore.Model.EntityBuilders
{
    public class MenuBuilder
    {
        public MenuBuilder(EntityTypeBuilder<Menu> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entityBuilder
                .HasOne(e => e.MenuLocation)
                .WithOne(l => l.Menu)
                .HasForeignKey<MenuLocation>(m => m.MenuId)
                .HasForeignKey<Menu>(m=>m.MenuLocationId);
            entityBuilder
                .HasMany(I => I.MenuItems)
                .WithOne(m => m.Menu)
                .HasForeignKey(s => s.MenuId);
        }
    }
}
