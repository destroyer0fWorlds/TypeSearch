
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Operator which describes how to evaluate a field against a range of values
    /// </summary>
    public enum RangeOperator
    {
        /// <summary>
		/// Filter for all records that fall between the range of two specified values (inclusive)
		/// </summary>
		Between = 0,
        /// <summary>
        /// Fitler for all records that fall outside the range of two specified values (exclusive)
        /// </summary>
        NotBetween = 1
    }
}
