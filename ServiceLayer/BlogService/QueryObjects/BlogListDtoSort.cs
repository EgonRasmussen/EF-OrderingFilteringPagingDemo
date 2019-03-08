using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ServiceLayer.BlogService.QueryObjects
{
    public enum OrderByOptions
    {
        [Display(Name = "Sort by Url ↓...")]
        SimpleOrder = 0,
        [Display(Name = "Ratings ↑")]
        ByRatings,
        [Display(Name = "Owner ↓")]
        ByOwner,
        [Display(Name = "Number of Posts ↑")]
        ByNumberOfPosts
    }

    public static class BlogListDtoSort
    {
        public static IQueryable<BlogListDto> OrderBlogsBy(this IQueryable<BlogListDto> blogs, OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.SimpleOrder:
                    return blogs.OrderBy(x => x.Url);

                case OrderByOptions.ByRatings:
                    return blogs.OrderByDescending(x => x.Rating);

                case OrderByOptions.ByOwner:
                    return blogs.OrderBy(x => x.Owner);

                case OrderByOptions.ByNumberOfPosts:
                    return blogs.OrderByDescending(x => x.NumberOfPosts);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }
    }
}
