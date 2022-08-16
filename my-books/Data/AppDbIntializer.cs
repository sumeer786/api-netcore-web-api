using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbIntializer
    {
       public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any()) 
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Title",
                        Description = "1st Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Bio",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2nd Title",
                        Description = "2nd Description",
                        IsRead = false,
                        Genre = "Bio",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
