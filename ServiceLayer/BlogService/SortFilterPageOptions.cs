using ServiceLayer.BlogService.QueryObjects;

namespace ServiceLayer.BlogService
{
    public class SortFilterPageOptions
    {
        public OrderByOptions OrderByOptions { get; set; }


        public BlogsFilterBy FilterBy { get; set; }
        public string FilterValue { get; set; }
    }
}
