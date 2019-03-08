using DataLayer;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BlogService.QueryObjects;
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
                .OrderBlogsBy(options.OrderByOptions)
                .FilterBlogsBy(options.FilterBy, options.FilterValue);
            
                options.SetupRestOfDto(blogsQuery);                             // Added
                return blogsQuery.Page(options.PageNum - 1, options.PageSize);  // Added
        }
    }
}
