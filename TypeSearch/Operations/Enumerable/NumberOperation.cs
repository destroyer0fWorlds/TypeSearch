using TypeSearch.Criteria;

namespace TypeSearch.Operations.Enumerable
{
    /// <inheritdoc />
    public class NumberOperation<T, TResult> : Operations.NumberOperation<T, TResult>
        where T : class
    {
        private readonly string _collectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NumberOperation(string collectionName, string propertyName, LogicalOperator @operator, WhereCriteria<T> where) : base(propertyName, @operator, where)
        {
            _collectionName = collectionName;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateGreaterThanCriteria(TResult value)
        {
            var criteria = base.CreateGreaterThanCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateBetweenCriteria(TResult startValue, TResult endValue)
        {
            var criteria = base.CreateBetweenCriteria(startValue, endValue);
            criteria.RangeCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateGreaterThanOrEqualToCriteria(TResult value)
        {
            var criteria = base.CreateGreaterThanOrEqualToCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateLessThanCriteria(TResult value)
        {
            var criteria = base.CreateLessThanCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateLessThanOrEqualToCriteria(TResult value)
        {
            var criteria = base.CreateLessThanOrEqualToCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateNotBetweenCriteria(TResult startValue, TResult endValue)
        {
            var criteria = base.CreateNotBetweenCriteria(startValue, endValue);
            criteria.RangeCriterion.CollectionName = _collectionName;
            return criteria;
        }
    }
}
