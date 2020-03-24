using System.Collections.Generic;

namespace TypeSearch.Criteria.Factory
{
    /// <summary>
    /// Factory responsible for creating filter criteria
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface ICriteriaFactory<T, TResult>
        where T : class
    {
        /// <summary>
        /// Create a criteria that evaluates to: property == value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateEqualToCriteria(TResult value);

        /// <summary>
        /// Create a criteria that evaluates to: property != value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateNotEqualToCriteria(TResult value);

        /// <summary>
        /// Create a criteria that evaluates to: property in (value1, value2, ...)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateInCriteria(IEnumerable<TResult> values);

        /// <summary>
        /// Create a criteria that evaluates to: property not in (value1, value2, ...)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateNotInCriteria(IEnumerable<TResult> values);

        /// <summary>
        /// Create a criteria that evaluates to: property contains value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateContainsCriteria(string value);

        /// <summary>
        /// Create a criteria that evaluates to: property not contains value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateNotContainsCriteria(string value);

        /// <summary>
        /// Create a criteria that evaluates to: property ends with value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateEndsWithCriteria(string value);

        /// <summary>
        /// Create a criteria that evaluates to: property not ends with value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateNotEndsWithCriteria(string value);

        /// <summary>
        /// Create a criteria that evaluates to: property starts with value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateStartsWithCriteria(string value);

        /// <summary>
        /// Create a criteria that evaluates to: property not starts with value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateNotStartsWithCriteria(string value);

        /// <summary>
        /// Create a criteria that evaluates to: property between start and end
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateBetweenCriteria(TResult startValue, TResult endValue);

        /// <summary>
        /// Create a criteria that evaluates to: property not between start and end
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateNotBetweenCriteria(TResult startValue, TResult endValue);

        /// <summary>
        /// Create a criteria that evaluates to: property > value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateGreaterThanCriteria(TResult value);

        /// <summary>
        /// Create a criteria that evaluates to: property >= value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateGreaterThanOrEqualToCriteria(TResult value);

        /// <summary>
        /// Create a criteria that evaluates to: property &lt; value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateLessThanCriteria(TResult value);

        /// <summary>
        /// Create a criteria that evaluates to: property &lt;= value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CriteriaContainer<T> CreateLessThanOrEqualToCriteria(TResult value);

        /// <summary>
        /// Create a criteria that evaluates to: property is null
        /// </summary>
        /// <returns></returns>
        CriteriaContainer<T> CreateNullCriteria();

        /// <summary>
        /// Create a criteria that evaluates to: property is not null
        /// </summary>
        /// <returns></returns>
        CriteriaContainer<T> CreateNotNullCriteria();

        /// <summary>
        /// Create a criteria that evaluates to: property == false
        /// </summary>
        /// <returns></returns>
        CriteriaContainer<T> CreateFalseCriteria();

        /// <summary>
        /// Create a criteria that evaluates to: property == true
        /// </summary>
        /// <returns></returns>
        CriteriaContainer<T> CreateTrueCriteria();
    }
}
