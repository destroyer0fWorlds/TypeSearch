using System;
using System.Collections.Generic;
using System.Linq;
using TypeSearch.Criteria;

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
        protected FilterCriteria<T> Where { get; private set; }

        /// <summary>
        /// Property name
        /// </summary>
        protected string PropertyName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public ObjectOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> where)
        {
            this.PropertyName = propertyName;
            this.Operator = @operator;
            this.Where = where;
        }

        /// <summary>
        /// The property's value must be present in the given collection of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public FilterCriteria<T> In(IEnumerable<TResult> values)
        {
            if (values == null || !values.Any())
            {
                throw new ArgumentNullException(nameof(values), $"'{nameof(In)}' function must be supplied with criteria. Parameter '{nameof(values)}' cannot be null or empty.");
            }

            // Add the IN criteria as a sub criteria to the main query
            this.Where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                NestedFilter = this.CreateInCriteria(values)
            });

            return this.Where;
        }

        /// <summary>
        /// The property's value must be present in the given collection of values
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public FilterCriteria<T> In(params TResult[] inList)
        {
            return this.In(values: inList);
        }

        /// <summary>
        /// Create a criteria that evaluates to: property in (value1, value2, ...)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        protected virtual FilterCriteria<T> CreateInCriteria(IEnumerable<TResult> values)
        {
            var inList = new FilterCriteria<T>();
            foreach (var value in values)
            {
                inList.Criteria.Add(new CriteriaContainer<T>()
                {
                    Operator = LogicalOperator.Or,
                    SingleCriterion = new SingleCriterion<T>()
                    {
                        Name = this.PropertyName,
                        Operator = SingleOperator.Equals,
                        Value = value
                    }
                });
            }
            return inList;
        }

        /// <summary>
        /// The property's value must be equal to the given value (value not reference equality)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> IsEqualTo(TResult value)
        {
            this.Where.Criteria.Add(this.CreateEqualToCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property == value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateEqualToCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.Equals,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must not be equal to the given value (value not reference equality)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> IsNotEqualTo(TResult value)
        {
            this.Where.Criteria.Add(this.CreateNotEqualToCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property != value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateNotEqualToCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.NotEquals,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must not be present in the given collection of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public FilterCriteria<T> NotIn(IEnumerable<TResult> values)
        {
            if (values == null || !values.Any())
            {
                throw new ArgumentNullException(nameof(values), $"'{nameof(NotIn)}' function must be supplied with criteria. Parameter '{nameof(values)}' cannot be null or empty.");
            }

            // Add the NOT IN criteria as a sub criteria to the main query
            this.Where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                NestedFilter = this.CreateNotInCriteria(values)
            });

            return this.Where;
        }

        /// <summary>
        /// The property's value must not be present in the given collection of values
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public FilterCriteria<T> NotIn(params TResult[] inList)
        {
            return this.NotIn(values: inList);
        }

        /// <summary>
        /// Create a criteria that evaluates to: property not in (value1, value2, ...)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        protected virtual FilterCriteria<T> CreateNotInCriteria(IEnumerable<TResult> values)
        {
            var inList = new FilterCriteria<T>();
            foreach (var value in values)
            {
                inList.Criteria.Add(new CriteriaContainer<T>()
                {
                    Operator = LogicalOperator.And,
                    SingleCriterion = new SingleCriterion<T>()
                    {
                        Name = this.PropertyName,
                        Operator = SingleOperator.NotEquals,
                        Value = value
                    }
                });
            }
            return inList;
        }
    }
}
