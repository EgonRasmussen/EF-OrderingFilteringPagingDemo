using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ServiceLayer.BlogService
{
    public class ListBlogService
    {
        // Dependency Injection of Context
        private readonly BloggingContext _context;
        public ListBlogService(BloggingContext context)
        {
            _context = context;
        }

        public IQueryable<BlogListDto> SortFilterPage()
        {
            var blogsQuery = _context.Blogs
                .AsNoTracking()
                .MapBlogToDto();
            return blogsQuery;
        }
    }
}
