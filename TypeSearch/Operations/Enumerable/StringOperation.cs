using TypeSearch.Criteria;

namespace TypeSearch.Operations.Enumerable
{
    /// <inheritdoc />
    public class StringOperation<T, TResult> : Operations.StringOperation<T, TResult>
        where T : class
    {
        private readonly string _collectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public StringOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> where) : base(propertyName, @operator, where)
        {
            _collectionName = collectionName;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateContainsCriteria(string value)
        {
            var criteria = base.CreateContainsCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateEndsWithCriteria(string value)
        {
            var criteria = base.CreateEndsWithCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateNotContainsCriteria(string value)
        {
            var criteria = base.CreateNotContainsCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateNotEndsWithCriteria(string value)
        {
            var criteria = base.CreateNotEndsWithCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateNotStartsWithCriteria(string value)
        {
            var criteria = base.CreateNotStartsWithCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateStartsWithCriteria(string value)
        {
            var criteria = base.CreateStartsWithCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }
    }
}
