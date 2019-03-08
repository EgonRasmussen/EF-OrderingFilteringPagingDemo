using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ServiceLayer.BlogService
{
    public class ListBlogService
    {
        private readonly BloggingContext _context;

        public ListBlogService(BloggingContext context)
        {
            _context = context;
        }

        public IQueryable<BlogListDto> SortFilterPage(SortFilterPageOptions options)
        {
            var blogsQuery = _context.Blogs
                .AsNoTracking()
                .MapBlogToDto()
                .OrderBlogsBy(options.OrderByOptions);      // Added Ordering
            return blogsQuery;
        }
    }
}
