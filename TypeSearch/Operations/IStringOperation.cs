
namespace TypeSearch.Operations
{
    /// <summary>
    /// Interface which describes the behavior of string operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStringOperation<T>
        where T : class
    {
        /// <summary>
        /// The property's value must contain the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> Contains(string value);

        /// <summary>
        /// The property's value must not contain the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> DoesNotContain(string value);

        /// <summary>
        /// The property's value must start with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> StartsWith(string value);

        /// <summary>
        /// The property's value must not start with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> DoesNotStartWith(string value);

        /// <summary>
        /// The property's value must end with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> EndsWith(string value);

        /// <summary>
        /// The property's value must not end with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        WhereCriteria<T> DoesNotEndWith(string value);
    }
}
