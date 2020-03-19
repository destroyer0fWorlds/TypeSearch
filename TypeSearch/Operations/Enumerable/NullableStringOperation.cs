﻿
namespace TypeSearch.Operations.Enumerable
{
    /// <summary>
    /// Exposes the operations available to nullable string types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class NullableStringOperation<T, TResult> : StringOperation<T, TResult>, INullableOperation<T>
        where T : class
    {
        private readonly NullableOperation<T, string> _nullableOperation;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableStringOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableStringOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> where) : base(collectionName, propertyName, @operator, where)
        {
            _nullableOperation = new NullableOperation<T, string>(collectionName, propertyName, @operator, where);
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
