using Microsoft.EntityFrameworkCore;
using PaginationAndSorting.Pagination.Constant;
using System.Linq.Expressions;

namespace PaginationAndSorting.Pagination
{
    /// <summary>
    /// Provides extension methods for pagination and sorting on IQueryable collections.
    /// </summary>
    public static class PaginationAndSortingBase
    {
        /// <summary>
        /// Asynchronously paginates an <see cref="IQueryable{T}"/> collection based on the provided page and page size.
        /// </summary>
        /// <typeparam name="T">The type of the data in the query.</typeparam>
        /// <param name="query">The <see cref="IQueryable{T}"/> collection to paginate.</param>
        /// <param name="page">The current page number.</param>
        /// <param name="perPage">The number of items per page.</param>
        /// <returns>A task that represents the asynchronous operation, containing the paginated <see cref="ResponsePagination{T}"/> object.</returns>
        public static async Task<ResponsePagination<T>> PaginateAsync<T>(this IQueryable<T> query, int page, int perPage)
        {
            // Gets the total number of items in the query.
            var total = await query.CountAsync();

            // Creates a pagination object with the total number of items, current page, and items per page.
            var pagination = new Pagination(total, page, perPage);

            // Retrieves the number of items per page.
            int sizePage = pagination.PerPage;

            // Retrieves the current page number.
            int currentPage = pagination.CurrentPage;

            // Adjusts the current page number for 0-based pagination (subtracts 1 to match the query logic).
            if (currentPage > 0) currentPage = page - 1;

            // Paginates the query by skipping items based on the current page and taking the specified number of items per page.
            var data = await query.Skip(currentPage * sizePage).Take(sizePage).ToListAsync();

            // Returns a paginated response with the data and pagination information.
            return new ResponsePagination<T>(pagination)
            {
                Data = data
            };

        }

        /// <summary>
        /// Orders an <see cref="IQueryable{T}"/> collection by the specified sort field and direction.
        /// </summary>
        /// <typeparam name="T">The type of the data in the query.</typeparam>
        /// <param name="query">The <see cref="IQueryable{T}"/> collection to sort.</param>
        /// <param name="sortField">The field by which to sort.</param>
        /// <param name="sortDirection">The sorting direction, either "asc" for ascending or "desc" for descending.</param>
        /// <param name="keySelector">A fallback key selector expression used when no sortField or sortDirection is provided.</param>
        /// <returns>An <see cref="IQueryable{T}"/> collection sorted according to the provided parameters.</returns>
        public static IQueryable<T> OrderBySortFiled<T>(this IQueryable<T> query,
            string? sortField,
            string? sortDirection,
            Expression<Func<T, object>> keySelector)
        {
            // Dynamic sorting
            if (sortField != null && sortDirection != null)
            {
                var parameter = Expression.Parameter(typeof(T), "x"); // Creates a parameter of type T: {x =>}
                var property = Expression.PropertyOrField(parameter, sortField); // Accesses the field or property: {x => x.[sortField]}

                // Create the lambda expression: x => x.[sortField]
                var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);
                /// <summary>
                /// Orders an <see cref="IQueryable{T}"/> collection based on the provided sorting field and direction.
                /// </summary>
                /// <typeparam name="T">The type of the items in the query.</typeparam>
                /// <param name="query">The <see cref="IQueryable{T}"/> collection to be sorted.</param>
                /// <param name="sortDirection">The direction in which to sort ("ASC" for ascending, "DESC" for descending).</param>
                /// <param name="lambda">An expression that represents the field by which the query will be sorted.</param>
                /// <param name="keySelector">A fallback key selector to sort by when no sorting field or direction is provided.</param>
                /// <returns>Returns the sorted <see cref="IQueryable{T}"/> collection.</returns>
                // Determine how to sort the query based on the provided sortDirection
                query = sortDirection?.ToUpper() switch
                {
                    // Sort in ascending order if sortDirection is "ASC"
                    SortOrder.Ascendent => query.OrderBy(lambda),

                    // Sort in descending order if sortDirection is "DESC"
                    SortOrder.Desendent => query.OrderByDescending(lambda),

                    // Default to descending order if sortDirection is not specified
                    _ => query.OrderByDescending(lambda),
                };
            }
            // If no sorting field or direction is provided, use the keySelector to sort in descending order
            else
            {
                query = query.OrderByDescending(keySelector);
            }
            // Return the sorted query
            return query;
        }
    }
}
