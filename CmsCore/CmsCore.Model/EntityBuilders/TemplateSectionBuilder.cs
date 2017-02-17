using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class TemplateSectionBuilder
    {
        public TemplateSectionBuilder(EntityTypeBuilder<TemplateSection> entityBuilder)
        {
            entityBuilder.HasKey(pc => new { pc.TemplateId, pc.SectionId });

            entityBuilder.HasOne(bc => bc.Template)
                .WithMany(b => b.TemplateSections)
                .HasForeignKey(bc => bc.TemplateId);

            entityBuilder.HasOne(bc => bc.Section)
                .WithMany(c => c.TemplateSections)
                .HasForeignKey(bc => bc.SectionId);
        }
    }
}
