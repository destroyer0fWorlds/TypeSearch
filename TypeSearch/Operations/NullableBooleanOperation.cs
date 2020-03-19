
namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to nullable boolean types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NullableBooleanOperation<T> : BooleanOperation<T, bool?>, INullableOperation<T>
        where T : class
    {
        private readonly NullableOperation<T, bool?> _nullableOperation;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableBooleanOperation{T}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public NullableBooleanOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(propertyName, @operator, filter)
        {
            _nullableOperation = new NullableOperation<T, bool?>(propertyName, @operator, filter);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableBooleanOperation{T}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public NullableBooleanOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(collectionName, propertyName, @operator, filter)
        {
            _nullableOperation = new NullableOperation<T, bool?>(collectionName, propertyName, @operator, filter);
        }

        /// <inheritdoc />
        public FilterCriteria<T> IsNotNull()
        {
            return _nullableOperation.IsNotNull();
        }

        /// <inheritdoc />
        public FilterCriteria<T> IsNull()
        {
            return _nullableOperation.IsNull();
        }
    }
}
