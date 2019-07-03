using System;
using Ecooperation_backend.Entities;
using Ecooperation_backend.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Ecooperation_backend.Migrations
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                if (context.Users.Any() || context.Projects.Any() || context.Tags.Any())
                {
                    return;
                }

                context.Tags.AddRange(
                    new Tag
                    {
                        Name = "tagName 1"
                    },
                    new Tag
                    {
                        Name = "tagName 2"
                    }
                );
                context.SaveChanges();

                context.Projects.AddRange(
                    new Project
                    {
                        Title = "title 1"
                    },
                    new Project
                    {
                        Title = "title 2"
                    }
                );
                context.SaveChanges();
            }

        }
    }
}