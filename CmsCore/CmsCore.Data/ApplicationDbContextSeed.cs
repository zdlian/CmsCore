using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(this ApplicationDbContext context)
        {
            
            context.Database.Migrate();

            // Perform seed operations
            AddPages(context);
            AddMenus(context);
            AddMenuItems(context);
            AddMenuLocations(context);


            // Save changes and release resources
            //context.SaveChanges();
            context.Dispose();
        }
        static Menu menu;
        private static void AddPages(ApplicationDbContext context)
        {
            context.AddRange(
                new Page { Title = "Merhaba", Slug = "merhaba", Body = "Hoşgeldiniz" }
                );
        }
        private static void AddMenus(ApplicationDbContext context)
        {
            menu = new Menu { Name = "name" };
            context.AddRange(menu
                
                );
        }private static void AddMenuItems(ApplicationDbContext context)
        {
            context.AddRange(
                new MenuItem { Name = "MenuLocname", Url="url",Menu=menu}
                );
        }
        private static void AddMenuLocations(ApplicationDbContext context)
        {
            context.AddRange(
                new MenuLocation {Name = "MenuLocname", Menu=menu}
                );
        }
        
    }
}
