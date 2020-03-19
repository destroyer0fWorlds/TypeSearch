using System;
using System.Collections.Generic;
using System.Linq;
using TypeSearch.Criteria;

namespace TypeSearch.Operations.Enumerable
{
    /// <inheritdoc />
    public class ObjectOperation<T, TResult> : Operations.ObjectOperation<T, TResult>
        where T : class
    {
        private readonly string _collectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public ObjectOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> where) : base(propertyName, @operator, where)
        {
            _collectionName = collectionName;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateEqualToCriteria(TResult value)
        {
            var criteria = base.CreateEqualToCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override FilterCriteria<T> CreateInCriteria(IEnumerable<TResult> values)
        {
            var criteria = base.CreateInCriteria(values);
            foreach (var criterion in criteria.Criteria)
            {
                criterion.SingleCriterion.CollectionName = _collectionName;
            }
            return criteria;
        }

        /// <inheritdoc />
        protected override CriteriaContainer<T> CreateNotEqualToCriteria(TResult value)
        {
            var criteria = base.CreateNotEqualToCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        protected override FilterCriteria<T> CreateNotInCriteria(IEnumerable<TResult> values)
        {
            var criteria = base.CreateNotInCriteria(values);
            foreach (var criterion in criteria.Criteria)
            {
                criterion.SingleCriterion.CollectionName = _collectionName;
            }
            return criteria;
        }
    }
}
