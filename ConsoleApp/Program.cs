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
            using (var context = new BloggingContext())
            {
                var blogService = new ListBlogService(context);

                var blogs = blogService.SortFilterPage(new SortFilterPageOptions
                {
                    OrderByOptions = OrderByOptions.SimpleOrder
                }).ToList();

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
    }
}
