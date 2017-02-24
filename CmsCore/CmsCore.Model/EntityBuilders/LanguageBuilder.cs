using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.EntityBuilders
{
    public class LanguageBuilder
    {
        public LanguageBuilder(EntityTypeBuilder<Language> entityBuilder)
        {
            entityBuilder.HasKey(s=>s.Id);
        }
    }
}
