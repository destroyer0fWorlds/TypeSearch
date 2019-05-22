using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch
{
    /// <summary>
    /// Search result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchResult<T>
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
        /// Number of records available in the raw dataset
        /// </summary>
        public int TotalRecordCount { get; set; }

        /// <summary>
        /// Number of records returned in the filtered dataset
        /// </summary>
        public int FilteredRecordCount { get; set; }

        /// <summary>
        /// Filtered dataset
        /// </summary>
        public List<T> ResultSet { get; set; }
    }
}
