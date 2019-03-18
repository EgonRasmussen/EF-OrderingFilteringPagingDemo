// DataLayer kræver følgende Nugets
//      Install-Package Microsoft.EntityFrameworkCore.SqlServer
//      Install-Package Microsoft.Extensions.Logging.Console
//      Install-Package Microsoft.EntityFrameworkCore.Tools
// ConsoleApp kræver følgende NuGet:
//      Install-Package Microsoft.EntityFrameworkCore.Design

using DataLayer;
using ServiceLayer.BlogService;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeDb();

            using (var context = new BloggingContext())
            {
                var blogService = new ListBlogService(context);

                var blogs = blogService.SortFilterPage().ToList();

                foreach (BlogListDto blog in blogs)
                {
                    Console.WriteLine("\nBlogId: {0} \nUrl: {1} \nRating: {2} \nOwner {3} \nNumber of Posts: {4}",
                        blog.BlogId,
                        blog.Url,
                        blog.Rating,
                        blog.Owner,
                        blog.NumberOfPosts
                        );
                }
            }
        }

        private static void InitializeDb()
        {
            using (var context = new BloggingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Console.WriteLine("Database recreated");
            }
        }
    }
}
