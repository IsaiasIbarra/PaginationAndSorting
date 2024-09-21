using System.ComponentModel;

namespace PaginationAndSorting.Pagination
{
    /// <summary>
    /// Represents a base request class that handles pagination and sorting parameters.
    /// </summary>
    public class Request
    {
        private int _page;
        private int _perPage;

        /// <summary>
        /// Gets or sets the current page number. 
        /// Defaults to 1 if the provided value is less than or equal to 0.
        /// </summary>
        [DefaultValue(1)]
        public int Page
        {
            get => _page <= 0 ? 1 : _page;
            set => _page = value;
        }

        /// <summary>
        /// Gets or sets the number of items per page. 
        /// Defaults to 10 if the provided value is less than or equal to 0.
        /// </summary>
        [DefaultValue(10)]
        public int PerPage
        {
            get => _perPage <= 0 ? 10 : _perPage;
            set => _perPage = value;
        }

        /// <summary>
        /// Gets or sets the field used for sorting.
        /// </summary>
        public string? SortField { get; set; }

        /// <summary>
        /// Gets or sets the sorting direction (e.g., "asc" for ascending, "desc" for descending).
        /// </summary>
        public string? SortDirection { get; set; }
    }

    /// <summary>
    /// Represents a request class specifically for pagination without any filters.
    /// </summary>
    public class RequestPagination : Request
    {
    }

    /// <summary>
    /// Represents a request class that includes pagination and supports filtering based on a provided filter type.
    /// </summary>
    /// <typeparam name="T">The type of filter applied to the request.</typeparam>
    public class RequestPaginationFilter<T> : Request
    {
        /// <summary>
        /// Gets or sets the filter applied to the pagination request.
        /// </summary>
        public T? Filter { get; set; }
    }
}
