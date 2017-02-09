using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data
{
    public static class DbContextExtensions
    {
        public static void Seed(this ApplicationDbContext context)
        {
            
            context.Database.Migrate();

            // Perform seed operations
            AddPages(context);
            

            // Save changes and release resources
            context.SaveChanges();
            context.Dispose();
        }

        private static void AddPages(ApplicationDbContext context)
        {
            context.AddRange(
                new Page { Title = "Merhaba", Slug = "merhaba", Body = "Hoşgeldiniz" }
                );
        }
}
}
