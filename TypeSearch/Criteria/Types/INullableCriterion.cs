using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Interface which describes the behavior of the most basic level of operations available for any type of nullable criterion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INullableCriterion<T>
        where T : class
    {
        /// <summary>
        /// The property's value must be null
        /// </summary>
        /// <returns></returns>
        WhereCriteria<T> IsNull();

        /// <summary>
        /// The property's value must not be null
        /// </summary>
        /// <returns></returns>
        WhereCriteria<T> IsNotNull();
    }
}
