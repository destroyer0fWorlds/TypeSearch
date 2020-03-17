using System;
using System.Collections.Generic;
using System.Linq;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Exposes the most basic level of operations available for any type of criterion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class ObjectCriterion<T, TResult> : BaseCriterion, IObjectCriterion<T, TResult>
        where T : class
    {
        /// <summary>
        /// Operator
        /// </summary>
        protected readonly LogicalOperator _operator;

        /// <summary>
        /// Where criteria
        /// </summary>
        protected readonly WhereCriteria<T> _where;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectCriterion{T, TResult}"/> class
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public ObjectCriterion(string name, LogicalOperator @operator, WhereCriteria<T> where) : base(name)
        {
            _operator = @operator;
            _where = where;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectCriterion{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public ObjectCriterion(string collectionName, string name, LogicalOperator @operator, WhereCriteria<T> where) : base(collectionName, name)
        {
            _operator = @operator;
            _where = where;
        }

        /// <summary>
        /// The property's value must be equal to the given value (value not reference equality)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> IsEqualTo(TResult value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.Equals,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must not be equal to the given value (value not reference equality)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> IsNotEqualTo(TResult value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.NotEquals,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must be present in the given collection of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public WhereCriteria<T> In(IEnumerable<TResult> values)
        {
            if (values == null || !values.Any())
            {
                throw new ArgumentNullException(nameof(values), $"'{nameof(In)}' function must be supplied with criteria. Parameter '{nameof(values)}' cannot be null or empty.");
            }

            // Build the IN criteria as a single filter criteria collection
            var inList = new WhereCriteria<T>();
            foreach (var value in values)
            {
                inList.Criteria.Add(new CriteriaContainer<T>()
                {
                    Operator = LogicalOperator.Or,
                    SingleCriterion = new SingleCriterion<T>()
                    {
                        Name = this.Name,
                        Operator = SingleOperator.Equals,
                        Value = value
                    }
                });
            }

            // Add the IN criteria as a sub criteria to the main query
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                NestedFilter = inList
            });

            return _where;
        }

        /// <summary>
        /// The property's value must be present in the given collection of values
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public WhereCriteria<T> In(params TResult[] inList)
        {
            return this.In(values: inList);
        }

        /// <summary>
        /// The property's value must not be present in the given collection of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public WhereCriteria<T> NotIn(IEnumerable<TResult> values)
        {
            if (values == null || !values.Any())
            {
                throw new ArgumentNullException(nameof(values), $"'{nameof(NotIn)}' function must be supplied with criteria. Parameter '{nameof(values)}' cannot be null or empty.");
            }

            // Build the NOT IN criteria as a single filter criteria collection
            var inList = new WhereCriteria<T>();
            foreach (var value in values)
            {
                inList.Criteria.Add(new CriteriaContainer<T>()
                {
                    Operator = LogicalOperator.And,
                    SingleCriterion = new SingleCriterion<T>()
                    {
                        Name = this.Name,
                        Operator = SingleOperator.NotEquals,
                        Value = value
                    }
                });
            }

            // Add the NOT IN criteria as a sub criteria to the main query
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                NestedFilter = inList
            });

            return _where;
        }

        /// <summary>
        /// The property's value must not be present in the given collection of values
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public WhereCriteria<T> NotIn(params TResult[] inList)
        {
            return this.NotIn(values: inList);
        }
    }
}
