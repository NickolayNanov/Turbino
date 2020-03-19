namespace Turbino.Domain.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PaginatedList<SourceType> : List<SourceType>
    {
        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

        List<SourceType> Items { get; set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static IQueryable<SourceType> Create(IQueryable<SourceType> source, int pageIndex, int pageSize)
        {
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return items;
        }
    }
}
