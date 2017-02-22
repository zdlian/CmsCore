using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class MediaBuilder
    {
        public MediaBuilder(EntityTypeBuilder<Media> entityBuilder)
        {
            entityBuilder.HasKey(x=>x.Id);
            entityBuilder.Property(e=>e.Title).IsRequired().HasMaxLength(50);
        }
    }
}
