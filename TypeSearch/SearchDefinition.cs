
namespace TypeSearch
{
    /// <summary>
    /// Search definition
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchDefinition<T> 
        where T : class
    {
        /// <summary>
		/// Total records provided per page
		/// </summary>
		public int? RecordsPerPage { get; set; }

        /// <summary>
        /// Zero indexed page number
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Sort criteria
        /// </summary>
        public SortCriteria<T> Sort { get; set; }

        /// <summary>
        /// Filter criteria
        /// </summary>
        public FilterCriteria<T> Filter { get; set; }

        /// <summary>
        /// Filter criteria applied before all other criteria
        /// </summary>
        public FilterCriteria<T> PreFilter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchDefinition{T}"/> class
        /// </summary>
        public SearchDefinition()
        {
            this.Sort = new SortCriteria<T>();
            this.Filter = new FilterCriteria<T>();
            this.PreFilter = new FilterCriteria<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchDefinition{T}"/> class with the specified paging information
        /// </summary>
        /// <param name="page">Zero indexed page number</param>
        /// <param name="recordsPerPage">Number of records to return per page</param>
        public SearchDefinition(int page, int recordsPerPage) : this()
        {
            this.Page = page;
            this.RecordsPerPage = recordsPerPage;
        }
    }
}
