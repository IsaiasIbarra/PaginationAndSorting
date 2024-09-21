namespace PaginationAndSorting.Paginations
{
    // Defines a generic interface for pagination operations
    public interface IPaginator<T>
    {
        /// <summary>
        /// Paginates the given IQueryable collection based on the provided pagination request.
        /// </summary>
        /// <param name="query">The IQueryable collection to paginate.</param>
        /// <param name="request">The pagination request containing page number and items per page.</param>
        /// <returns>A task that represents the asynchronous operation, containing the paginated response.</returns>
        Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination request);

        /// <summary>
        /// Paginates the given IQueryable collection based on the provided pagination filter request.
        /// </summary>
        /// <param name="query">The IQueryable collection to paginate.</param>
        /// <param name="request">The pagination filter request containing page number, items per page, and filter criteria.</param>
        /// <returns>A task that represents the asynchronous operation, containing the paginated response.</returns>
        Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPaginationFilter<T> request);
    }
}
