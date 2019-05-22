using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Interface which describes the behavior of number specific operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface INumberCriterion<T, TResult>
        where T : class
    {
        /// <summary>
        /// The property's value must be greater than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> GreaterThan(TResult value);

        /// <summary>
        /// The property's value must be greater than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> GreaterThanOrEqualTo(TResult value);

        /// <summary>
        /// The property's value must be less than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> LessThan(TResult value);

        /// <summary>
        /// The property's value must be less than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> LessThanOrEqualTo(TResult value);

        /// <summary>
        /// The property's value must be between the given values (inclusive)
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        WhereCriteria<T> Between(TResult startValue, TResult endValue);

        /// <summary>
        /// The property's value must not be between the given values (exclusive)
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        WhereCriteria<T> NotBetween(TResult startValue, TResult endValue);
    }
}
