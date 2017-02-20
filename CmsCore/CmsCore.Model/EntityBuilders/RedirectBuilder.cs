using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class RedirectBuilder
    {
        public RedirectBuilder(EntityTypeBuilder<Redirect> entityBuilder)
        {
            entityBuilder.HasKey(s => s.Id);
            entityBuilder.Property(s => s.Name).IsRequired().HasMaxLength(200);
            entityBuilder.Property(s=>s.OldUrl).HasMaxLength(200);
            entityBuilder.Property(s=>s.NewUrl).HasMaxLength(200);
           
        }
    }
}
