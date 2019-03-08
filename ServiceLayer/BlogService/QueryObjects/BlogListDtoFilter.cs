using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ServiceLayer.BlogService.QueryObjects
{
    public enum BlogsFilterBy
    {
        [Display(Name = "All")]
        NoFilter = 0,
        [Display(Name = "By Owner...")]
        ByOwner,
        [Display(Name = "By Ratings...")]
        ByRatings
    }

    public static class BlogListDtoFilter
    {
        public static IQueryable<BlogListDto> FilterBlogsBy(this IQueryable<BlogListDto> blogs, BlogsFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return blogs;

            switch (filterBy)
            {
                case BlogsFilterBy.NoFilter:
                    return blogs;

                case BlogsFilterBy.ByOwner:
                    return blogs.Where(x => x.Owner == filterValue);

                case BlogsFilterBy.ByRatings:
                    return blogs.Where(x => x.Rating >= int.Parse(filterValue));

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
