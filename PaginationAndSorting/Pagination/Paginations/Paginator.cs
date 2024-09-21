namespace PaginationAndSorting.Pagination.Paginations
{
    // Implements the IPaginator interface for pagination of a generic type T
    public class Paginator<T> : IPaginator<T>
    {
        /// <summary>
        /// Paginates the given IQueryable collection based on the provided pagination request.
        /// </summary>
        /// <param name="query">The IQueryable collection to paginate.</param>
        /// <param name="request">The pagination request containing page number and items per page.</param>
        /// <returns>A task that represents the asynchronous operation, containing the paginated response.</returns>
        public Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination request)
        {
            // Calls the PaginateAsync extension method to perform pagination
            return query.PaginateAsync(request.Page, request.PerPage);
        }

        /// <summary>
        /// Paginates the given IQueryable collection based on the provided pagination filter request.
        /// </summary>
        /// <param name="query">The IQueryable collection to paginate.</param>
        /// <param name="request">The pagination filter request containing page number and items per page.</param>
        /// <returns>A task that represents the asynchronous operation, containing the paginated response.</returns>
        public Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPaginationFilter<T> request)
        {
            // Calls the PaginateAsync extension method to perform pagination
            return query.PaginateAsync(request.Page, request.PerPage);
        }
    }
}
