using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class MenuItemBuilder
    {
        public MenuItemBuilder(EntityTypeBuilder<MenuItem> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(m => m.Menu).WithMany(m => m.MenuItems).HasForeignKey(m => m.MenuId).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(m=>m.ParentMenuItem).WithMany(m=>m.ChildMenuItems).HasForeignKey(p => p.ParentMenuItemId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
