// Tilføjet ServiceLayer.BlogService.BlogListDtoSort.cs
// Tilføjet ServiceLayer.BlogService.SortFilterPageOptions.cs
// Udvidet ServiceLayer.BlogService.Concrete.ListBlogService.cs med .OrderBlogsBy()
// Udvidet ConsoleApp.Program.cs med SortFilterPageOptions

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
            //InitializeDb();

            using (var context = new BloggingContext())
            {
                var blogService = new ListBlogService(context);

                var blogs = blogService.SortFilterPage(new SortFilterPageOptions
                {
                    OrderByOptions = OrderByOptions.ByOwner
                }).ToList();

                Console.ForegroundColor = ConsoleColor.Green;
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
                Console.ForegroundColor = ConsoleColor.White;
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
