using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class TemplateSideBarBuilder
    {
        public TemplateSideBarBuilder(EntityTypeBuilder<TemplateSideBar> entityBuilder)
        {
            entityBuilder.HasKey(pc => new { pc.TemplateId, pc.SideBarId });

            entityBuilder.HasOne(bc => bc.Template)
                .WithMany(b => b.TemplateSideBars)
                .HasForeignKey(bc => bc.TemplateId);

            entityBuilder.HasOne(bc => bc.SideBar)
                .WithMany(c => c.TemplateSideBars)
                .HasForeignKey(bc => bc.SideBarId);
        }
    }
}
