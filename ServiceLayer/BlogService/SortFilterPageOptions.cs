using ServiceLayer.BlogService.QueryObjects;
using System;
using System.Linq;

namespace ServiceLayer.BlogService
{
    public class SortFilterPageOptions
    {
        #region ORDERING
        public OrderByOptions OrderByOptions { get; set; }
        #endregion

        #region FILTERING
        public BlogsFilterBy FilterBy { get; set; }
        public string FilterValue { get; set; }
        #endregion

        #region PAGING 
        public const int DefaultPageSize = 10;   //default page size is 10

        public int PageNum { get; set; }

        public int PageSize { get; set; } = DefaultPageSize;

        public int NumPages { get; private set; }

        public void SetupRestOfDto<T>(IQueryable<T> query)
        {
            NumPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            PageNum = Math.Min(Math.Max(1, PageNum), NumPages);
        }   
        #endregion
    }
}
