namespace ServiceLayer.BlogService
{
    public class BlogListDto
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int? Rating { get; set; }


        public string Owner { get; set; }       // New
        public int NumberOfPosts { get; set; }  // New
    }
}
