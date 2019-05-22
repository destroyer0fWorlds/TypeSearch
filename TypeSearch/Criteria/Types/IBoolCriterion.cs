using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Interface which describes the behavior of bool specific operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBoolCriterion<T>
        where T : class
    {
        /// <summary>
        /// The property's value must be true
        /// </summary>
        /// <returns></returns>
        WhereCriteria<T> IsTrue();

        /// <summary>
        /// The property's value must be false
        /// </summary>
        /// <returns></returns>
        WhereCriteria<T> IsFalse();
    }
}
