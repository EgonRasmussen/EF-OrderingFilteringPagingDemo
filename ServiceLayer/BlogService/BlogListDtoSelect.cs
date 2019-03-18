using DataLayer.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.BlogService
{
    public static class BlogListDtoSelect
    {
        public static IQueryable<BlogListDto> MapBlogToDto(this IQueryable<Blog> blogs)
        {
            return blogs.Select(b => new BlogListDto
            {
                BlogId = b.BlogId,
                Url = b.Url,
                Rating = b.Rating,   
                Owner = b.Owner.Name,
                NumberOfPosts = b.Posts.Count()
            });
        }
    }
}
