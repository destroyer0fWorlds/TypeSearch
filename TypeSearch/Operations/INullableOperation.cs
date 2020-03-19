
namespace TypeSearch.Operations
{
    /// <summary>
    /// Interface which describes the behavior nullable operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INullableOperation<T>
        where T : class
    {
        /// <summary>
        /// The property's value must be null
        /// </summary>
        /// <returns></returns>
        FilterCriteria<T> IsNull();

        /// <summary>
        /// The property's value must not be null
        /// </summary>
        /// <returns></returns>
        FilterCriteria<T> IsNotNull();
    }
}
