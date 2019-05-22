using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria
{
    /// <summary>
    /// Operator which describes how to evaluate a field against a single value
    /// </summary>
    public enum SingleOperator
    {
        /// <summary>
		/// Perform an equality comparison (exact match)
		/// </summary>
		Equals,
        /// <summary>
        /// Perform an inequality comparison (not exact match)
        /// </summary>
        NotEquals,
        /// <summary>
        /// Perform a like comparison (contains)
        /// </summary>
        Like,
        /// <summary>
        /// Perform a not like comparison (does not contain)
        /// </summary>
        NotLike,
        /// <summary>
        /// Results must be greater than the supplied value (string and bool are not supported)
        /// </summary>
        GreaterThan,
        /// <summary>
        /// Results must be greater than or equal to the supplied value (string and bool are not supported)
        /// </summary>
        GreaterThanOrEqualTo,
        /// <summary>
        /// Results must be less than the supplied value (string and bool are not supported)
        /// </summary>
        LessThan,
        /// <summary>
        /// Results must be less than or equal to the supplied value (string and bool are not supported)
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
        /// Results start with the specified value
        /// </summary>
        StartsWith,
        /// <summary>
        /// Results do not start with the specified value
        /// </summary>
        DoesNotStartWith,
        /// <summary>
        /// Results end with the specified value
        /// </summary>
        EndsWith,
        /// <summary>
        /// Results do not end with the specified value
        /// </summary>
        DoesNotEndWith
    }
}
