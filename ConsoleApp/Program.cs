// Tilføjet DataLayer.QueryObjects.GenericPaging.cs

// Udvidet ServiceLayer.BlogService.Concret.ListBlogService.cs med med .SetupRestOfDto() og PageNum og PageSize
// Udvidet ServiceLayer.BlogService.SortFilterPageOptions.cs med Paging
// Udvidet ConsoleApp.Program.cs med SortFilterPageOptions (PageNum og PageSize)

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
            using (var context = new BloggingContext())
            {
                // Tuples for DropDownControl i webclient
                //var blogFilterDropdownService = new BlogFilterDropdownService(context);
                //var dropdownItems = blogFilterDropdownService.GetFilterDropDownValues(BlogsFilterBy.ByOwner).ToList();

                //foreach (var item in dropdownItems)
                //{
                //    Console.WriteLine("{0} - {1}", item.Value, item.Text);
                //}




                var blogService = new ListBlogService(context);
                var blogs = blogService.SortFilterPage(new SortFilterPageOptions
                {
                    OrderByOptions = OrderByOptions.SimpleOrder,
                    //FilterBy = BlogsFilterBy.ByOwner,
                    //FilterValue = "Person 3"

                    PageNum = 1,
                    PageSize = 2
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
