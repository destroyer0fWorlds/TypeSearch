using TypeSearch.Criteria;

namespace TypeSearch.Operations.Enumerable
{
    /// <inheritdoc />
    public class BooleanOperation<T, TResult> : Operations.BooleanOperation<T, TResult>
        where T : class
    {
        private readonly string _collectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public BooleanOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> where) : base(propertyName, @operator, where)
        {
            _collectionName = collectionName;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateFalseCriteria()
        {
            var criteria = base.CreateFalseCriteria();
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateTrueCriteria()
        {
            var criteria = base.CreateTrueCriteria();
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }
    }
}
