using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BlogService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.BlogService.Concrete
{
    public class BlogFilterDropdownService
    {
        private readonly BloggingContext _db;

        public BlogFilterDropdownService(BloggingContext db)
        {
            _db = db;
        }

        public IEnumerable<DropdownTuple> GetFilterDropDownValues(BlogsFilterBy filterBy)
        {
            switch (filterBy)
            {
                case BlogsFilterBy.NoFilter:
                    return new List<DropdownTuple>();

                case BlogsFilterBy.ByRatings:
                    return FormRatingsDropDown();

                case BlogsFilterBy.ByOwner:
                    var result = _db.Blogs
                        .Include(x => x.Owner)
                        .Where(x => x.OwnerId != null)
                        .OrderBy(x => x.Owner.Name)
                        .Select(x => new DropdownTuple
                         {
                             Value = x.OwnerId.ToString(),
                             Text = x.Owner.Name
                         }).ToList();
                    return result;
                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }

        private static IEnumerable<DropdownTuple> FormRatingsDropDown()
        {
            return new[]
            {
                new DropdownTuple {Value = "4", Text = "4 stars and up"},
                new DropdownTuple {Value = "3", Text = "3 stars and up"},
                new DropdownTuple {Value = "2", Text = "2 stars and up"},
                new DropdownTuple {Value = "1", Text = "1 star and up"},
            };
        }
    }
}
