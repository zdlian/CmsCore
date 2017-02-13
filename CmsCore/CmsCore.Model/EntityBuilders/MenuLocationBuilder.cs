using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class MenuLocationBuilder
    {
        public MenuLocationBuilder(EntityTypeBuilder<MenuLocation> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder
                .HasOne(l => l.Menu)
                .WithOne(l=>l.MenuLocation)
                .HasForeignKey<MenuLocation>(m => m.MenuId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
