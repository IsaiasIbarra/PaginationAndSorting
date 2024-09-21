


namespace PaginationAndSorting.Pagination
{
    /// <summary>
    /// Represents a paginated response that includes a collection of data items of type <typeparamref name="T"/>.
    /// Inherits pagination information from the <see cref="Pagination"/> class.
    /// </summary>
    /// <typeparam name="T">The type of data items contained in the response.</typeparam>
    public class ResponsePagination<T> : Pagination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePagination{T}"/> class.
        /// Uses the total number of items, the current page, and the number of items per page to calculate pagination details.
        /// </summary>
        /// <param name="total">The total number of items.</param>
        /// <param name="page">The current page number.</param>
        /// <param name="perPage">The number of items per page.</param>
        public ResponsePagination(int total, int page, int perPage) : base(total, page, perPage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePagination{T}"/> class based on an existing <see cref="Pagination"/> object.
        /// </summary>
        /// <param name="pagination">An existing <see cref="Pagination"/> instance to copy pagination details from.</param>
        public ResponsePagination(Pagination pagination) : base(pagination)
        {
        }

        /// <summary>
        /// Gets or sets the collection of data items for the current page.
        /// </summary>
        public IReadOnlyList<T> Data { get; set; } = new List<T>();
    }
}
