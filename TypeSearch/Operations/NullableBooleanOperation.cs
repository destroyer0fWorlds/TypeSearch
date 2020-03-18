
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
        /// <param name="where">Parent filter criteria</param>
        public NullableBooleanOperation(string propertyName, LogicalOperator @operator, WhereCriteria<T> where) : base(propertyName, @operator, where)
        {
            _nullableOperation = new NullableOperation<T, bool?>(propertyName, @operator, where);
        }

        /// <inheritdoc />
        public WhereCriteria<T> IsNotNull()
        {
            return _nullableOperation.IsNotNull();
        }

        /// <inheritdoc />
        public WhereCriteria<T> IsNull()
        {
            return _nullableOperation.IsNull();
        }
    }
}
