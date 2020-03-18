
namespace TypeSearch.Operations.Enumerable
{
    /// <summary>
    /// Exposes the operations available to nullable boolean types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NullableBooleanOperation<T> : BooleanOperation<T, bool?>, INullableOperation<T>
        where T : class
    {
        private readonly NullableOperation<T, bool> _nullableOperation;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableBooleanOperation{T}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableBooleanOperation(string collectionName, string propertyName, LogicalOperator @operator, WhereCriteria<T> where) : base(collectionName, propertyName, @operator, where)
        {
            _nullableOperation = new NullableOperation<T, bool>(collectionName, propertyName, @operator, where);
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
