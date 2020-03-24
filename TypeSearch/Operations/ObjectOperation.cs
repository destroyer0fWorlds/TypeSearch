using System;
using System.Collections.Generic;
using System.Linq;
using TypeSearch.Criteria;
using TypeSearch.Criteria.Factory;

namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the most basic level of operations available to any type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class ObjectOperation<T, TResult> : IObjectOperation<T, TResult>
        where T : class
    {
        /// <summary>
        /// Operator
        /// </summary>
        protected LogicalOperator Operator { get; private set; }

        /// <summary>
        /// Where criteria
        /// </summary>
        protected FilterCriteria<T> Filter { get; private set; }

        /// <summary>
        /// Property name
        /// </summary>
        protected string PropertyName { get; private set; }

        /// <summary>
        /// Criteria factory
        /// </summary>
        protected ICriteriaFactory<T, TResult> CriteriaFactory { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public ObjectOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> filter)
        {
            this.PropertyName = propertyName;
            this.Operator = @operator;
            this.Filter = filter;
            this.CriteriaFactory = new CriteriaFactory<T, TResult>(propertyName, @operator);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public ObjectOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> filter)
        {
            this.PropertyName = propertyName;
            this.Operator = @operator;
            this.Filter = filter;
            this.CriteriaFactory = new EnumerableCriteriaFactory<T, TResult>(collectionName, propertyName, @operator);
        }

        /// <inheritdoc />
        public FilterCriteria<T> In(IEnumerable<TResult> values)
        {
            if (values == null || !values.Any())
            {
                throw new ArgumentNullException(nameof(values), $"'{nameof(In)}' function must be supplied with criteria. Parameter '{nameof(values)}' cannot be null or empty.");
            }

            // Add the IN criteria as a sub criteria to the main query
            this.Filter.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                NestedFilter = this.CriteriaFactory.CreateInCriteria(values)
            });

            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> In(params TResult[] inList)
        {
            return this.In(values: inList);
        }

        /// <inheritdoc />
        public FilterCriteria<T> IsEqualTo(TResult value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateEqualToCriteria(value));
            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> IsNotEqualTo(TResult value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateNotEqualToCriteria(value));
            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> NotIn(IEnumerable<TResult> values)
        {
            if (values == null || !values.Any())
            {
                throw new ArgumentNullException(nameof(values), $"'{nameof(NotIn)}' function must be supplied with criteria. Parameter '{nameof(values)}' cannot be null or empty.");
            }

            // Add the NOT IN criteria as a sub criteria to the main query
            this.Filter.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                NestedFilter = this.CriteriaFactory.CreateNotInCriteria(values)
            });

            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> NotIn(params TResult[] inList)
        {
            return this.NotIn(values: inList);
        }
    }
}
