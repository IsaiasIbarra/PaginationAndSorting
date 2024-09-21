namespace PaginationAndSorting.Pagination
{
    /// <summary>
    /// Represents a class that handles pagination logic.
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// Gets or sets the index of the first item on the current page.
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// Gets or sets the index of the last item on the current page.
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the last calculated page number.
        /// </summary>
        public int LastPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of items.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination"/> class.
        /// Calculates pagination information based on the total number of items, the current page, and the number of items per page.
        /// </summary>
        /// <param name="total">The total number of items.</param>
        /// <param name="page">The current page number.</param>
        /// <param name="perPage">The number of items per page.</param>
        public Pagination(int total, int page, int perPage)
        {
            int lastPage = (int)Math.Ceiling((double)total / perPage);
            int from = (page - 1) * perPage + 1;
            int to = (page * perPage);
            int currentPage = page;

            From = from;
            To = to;
            PerPage = perPage;
            CurrentPage = currentPage;
            LastPage = lastPage;
            Total = total;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination"/> class based on another pagination instance.
        /// </summary>
        /// <param name="pagination">An instance of <see cref="Pagination"/> to copy from.</param>
        public Pagination(Pagination pagination)
        {
            From = pagination.From;
            To = pagination.To;
            PerPage = pagination.PerPage;
            CurrentPage = pagination.CurrentPage;
            LastPage = pagination.LastPage;
            Total = pagination.Total;
        }
    }
}
