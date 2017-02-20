using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class SettingBuilder
    {
        public SettingBuilder(EntityTypeBuilder<Setting> entityBuilder)
        {
            entityBuilder.HasKey(s => s.Id);
            entityBuilder.Property(s => s.Name).HasMaxLength(200);
            entityBuilder.Property(s => s.Value).HasMaxLength(200);
        }
    }
}
