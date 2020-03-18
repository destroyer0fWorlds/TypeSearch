using System.Collections.Generic;

namespace TypeSearch.Operations
{
    /// <summary>
    /// Interface which describes the most basic level of operations available to any type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IObjectOperation<T, TResult>
        where T : class
    {
        /// <summary>
        /// The property's value must be equal to the given value (value not reference equality)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> IsEqualTo(TResult value);

        /// <summary>
        /// The property's value must not be equal to the given value (value not reference equality)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> IsNotEqualTo(TResult value);

        /// <summary>
        /// The property's value must be present in the given collection of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        WhereCriteria<T> In(IEnumerable<TResult> values);

        /// <summary>
        /// The property's value must be present in the given collection of values
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        WhereCriteria<T> In(params TResult[] inList);

        /// <summary>
        /// The property's value must not be present in the given collection of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        WhereCriteria<T> NotIn(IEnumerable<TResult> values);

        /// <summary>
        /// The property's value must not be present in the given collection of values
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        WhereCriteria<T> NotIn(params TResult[] inList);
    }
}
