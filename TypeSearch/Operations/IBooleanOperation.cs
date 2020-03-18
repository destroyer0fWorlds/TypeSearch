
namespace TypeSearch.Operations
{
    /// <summary>
    /// Interface which describes the behavior of bool operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBooleanOperation<T>
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
