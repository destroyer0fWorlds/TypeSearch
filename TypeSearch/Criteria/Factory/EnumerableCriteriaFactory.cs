﻿using System.Collections.Generic;

namespace TypeSearch.Criteria.Factory
{
    /// <summary>
    /// Factory responsible for creating filter criteria for collections
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    class EnumerableCriteriaFactory<T, TResult> : CriteriaFactory<T, TResult>
        where T : class
    {
        private readonly string _collectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableCriteriaFactory{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        public EnumerableCriteriaFactory(string collectionName, string propertyName, LogicalOperator @operator) : base(propertyName, @operator)
        {
            _collectionName = collectionName;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateBetweenCriteria(TResult startValue, TResult endValue)
        {
            var criteria = base.CreateBetweenCriteria(startValue, endValue);
            criteria.RangeCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateContainsCriteria(string value)
        {
            var criteria = base.CreateContainsCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateEndsWithCriteria(string value)
        {
            var criteria = base.CreateEndsWithCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateEqualToCriteria(TResult value)
        {
            var criteria = base.CreateEqualToCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateFalseCriteria()
        {
            var criteria = base.CreateFalseCriteria();
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateGreaterThanCriteria(TResult value)
        {
            var criteria = base.CreateGreaterThanCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateGreaterThanOrEqualToCriteria(TResult value)
        {
            var criteria = base.CreateGreaterThanOrEqualToCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateInCriteria(IEnumerable<TResult> values)
        {
            var criteria = base.CreateInCriteria(values);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateLessThanCriteria(TResult value)
        {
            var criteria = base.CreateLessThanCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateLessThanOrEqualToCriteria(TResult value)
        {
            var criteria = base.CreateLessThanOrEqualToCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateNotBetweenCriteria(TResult startValue, TResult endValue)
        {
            var criteria = base.CreateNotBetweenCriteria(startValue, endValue);
            criteria.RangeCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateNotContainsCriteria(string value)
        {
            var criteria = base.CreateNotContainsCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateNotEndsWithCriteria(string value)
        {
            var criteria = base.CreateNotEndsWithCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateNotEqualToCriteria(TResult value)
        {
            var criteria = base.CreateNotEqualToCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateNotInCriteria(IEnumerable<TResult> values)
        {
            var criteria = base.CreateNotInCriteria(values);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateNotNullCriteria()
        {
            var criteria = base.CreateNotNullCriteria();
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateNotStartsWithCriteria(string value)
        {
            var criteria = base.CreateNotStartsWithCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateNullCriteria()
        {
            var criteria = base.CreateNullCriteria();
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateStartsWithCriteria(string value)
        {
            var criteria = base.CreateStartsWithCriteria(value);
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }

        /// <inheritdoc />
        public override CriteriaContainer<T> CreateTrueCriteria()
        {
            var criteria = base.CreateTrueCriteria();
            criteria.SingleCriterion.CollectionName = _collectionName;
            return criteria;
        }
    }
}
