namespace Ecommerce.Application.Common.Dtos
{
    public class PaginationRespone<T> where T : class
    {
        public const int FIRST_PAGE = 1;
        public const int PAGE_SIZE_10 = 10;

        public int Page { get; protected set; }
        public int PageSize { get; protected set; }
        public int TotalCount { get; protected set; }
        public int TotalPages { get; protected set; }
        public IReadOnlyList<T> Data { get; set; }

        protected PaginationRespone()
        {
            Page = FIRST_PAGE;
            PageSize = PAGE_SIZE_10;
            Data = new List<T>();
        }

        public PaginationRespone(int count, int page, int pageSize, IReadOnlyList<T> data)
        {
            Data = data;
            Page = page;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        }

    }
}
