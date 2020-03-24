
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Operator which describes how to evaluate a field against a single value
    /// </summary>
    public enum SingleOperator
    {
        /// <summary>
		/// Results must be equal to the specified value (exact match)
		/// </summary>
		Equals,
        /// <summary>
        /// Results must not be equal to the specified value (not exact match)
        /// </summary>
        NotEquals,
        /// <summary>
        /// Results must be like the specified value (contains)
        /// </summary>
        Like,
        /// <summary>
        /// Result must not be like the specified value (does not contain)
        /// </summary>
        NotLike,
        /// <summary>
        /// Results must be greater than the specified value
        /// </summary>
        GreaterThan,
        /// <summary>
        /// Results must be greater than or equal to the specified value
        /// </summary>
        GreaterThanOrEqualTo,
        /// <summary>
        /// Results must be less than the specified value
        /// </summary>
        LessThan,
        /// <summary>
        /// Results must be less than or equal to the specified value
        /// </summary>
        LessThanOrEqualTo,
        /// <summary>
        /// Results must be NULL
        /// </summary>
        IsNull,
        /// <summary>
        /// Results must not be NULL
        /// </summary>
        IsNotNull,
        /// <summary>
        /// Results must start with the specified value
        /// </summary>
        StartsWith,
        /// <summary>
        /// Results must not start with the specified value
        /// </summary>
        DoesNotStartWith,
        /// <summary>
        /// Results must end with the specified value
        /// </summary>
        EndsWith,
        /// <summary>
        /// Results must not end with the specified value
        /// </summary>
        DoesNotEndWith,
        /// <summary>
        /// Results must be in the list of values specified
        /// </summary>
        In,
        /// <summary>
        /// Results must not be in the list of values specified
        /// </summary>
        NotIn
    }
}
