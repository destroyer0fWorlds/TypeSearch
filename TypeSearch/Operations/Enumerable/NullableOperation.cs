using TypeSearch.Criteria;

namespace TypeSearch.Operations.Enumerable
{
    /// <inheritdoc />
    public class NullableOperation<T, TResult> : Operations.NullableOperation<T, TResult>
        where T : class
    {
        private readonly string _collectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableOperation(string collectionName, string propertyName, LogicalOperator @operator, WhereCriteria<T> where) : base(propertyName, @operator, where)
        {
            _collectionName = collectionName;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateNotNullCriteria()
        {
            var criteria = base.CreateNotNullCriteria();
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateNullCriteria()
        {
            var criteria = base.CreateNullCriteria();
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }
    }
}
