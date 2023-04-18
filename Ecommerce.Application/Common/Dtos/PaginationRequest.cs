using Ecommerce.Application.Common.Enums;

namespace Ecommerce.Application.Common.Dtos
{
    public class PaginationRequest
    {
        public const int DEFAULT_PAGE_SIZE = 12;

        public PaginationRequest()
        {
            PageSize = DEFAULT_PAGE_SIZE;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public SortMetadata? SortMetadata { get; set; }
    }

    public class SortMetadata
    {
        public string? Field { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
