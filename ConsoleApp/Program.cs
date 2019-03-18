// Tilføjet ServiceLayer.BlogService.QueryObjects.BlogListDtoFilter.cs
// Udvidet ServiceLayer.BlogService.SortFilterPageOptions.cs
// Udvidet ServiceLayer.ListBlogService.cs med .FilterBlogsBy()
// Udvidet ConsoleApp.Program.cs med SortFilterPageOptions (FilterBy og FilterValue)

// Tilføjet ServiceLayer.BlogService.Concrete.BlogFilterDropdownService.cs
// Tilføjet ServiceLayer.BlogService.DropdownTuple.cs
// Udvidet ConsoleApp.Program.cs med demo af DropdownService

using DataLayer;
using ServiceLayer.BlogService;
using ServiceLayer.BlogService.Concrete;
using ServiceLayer.BlogService.QueryObjects;
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
                // Tuples for DropDownControl i webclient
                var blogFilterDropdownService = new BlogFilterDropdownService(context);
                var dropdownItems = blogFilterDropdownService.GetFilterDropDownValues(BlogsFilterBy.ByOwner).ToList();

                foreach (var item in dropdownItems)
                {
                    Console.WriteLine("{0} - {1}", item.Value, item.Text);
                }




                //var blogService = new ListBlogService(context);
                //var blogs = blogService.SortFilterPage(new SortFilterPageOptions
                //{
                //    OrderByOptions = OrderByOptions.SimpleOrder,
                //    FilterBy = BlogsFilterBy.ByOwner,
                //    FilterValue = "Person 3"
                //}).ToList();

                //foreach (BlogListDto blog in blogs)
                //{
                //    Console.WriteLine("\nBlogId: {0} \nUrl: {1} \nRating: {2} \nOwner {3} \nNumber of Posts: {4}",
                //        blog.BlogId,
                //        blog.Url,
                //        blog.Rating,
                //        blog.Owner,
                //        blog.NumberOfPosts
                //        );
                //}
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
