using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Exposes string specific operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StringCriterion<T> : ObjectCriterion<T, string>, INullableCriterion<T>, IStringCriterion<T>
        where T : class
    {
        private readonly NullableCriterion<T, string> _nullableCriterion;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringCriterion{T}"/> class
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public StringCriterion(string name, LogicalOperator @operator, WhereCriteria<T> where) : base(name, @operator, where)
        {
            _nullableCriterion = new NullableCriterion<T, string>(name, @operator, where);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringCriterion{T}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public StringCriterion(string collectionName, string name, LogicalOperator @operator, WhereCriteria<T> where) : base(collectionName, name, @operator, where)
        {
            _nullableCriterion = new NullableCriterion<T, string>(name, @operator, where);
        }

        /// <summary>
        /// The property's value must contain the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> Contains(string value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.Like,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must not contain the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> DoesNotContain(string value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.NotLike,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must not end with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> DoesNotEndWith(string value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.DoesNotEndWith,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must not start with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> DoesNotStartWith(string value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.DoesNotStartWith,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must end with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> EndsWith(string value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.EndsWith,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must not be null
        /// </summary>
        /// <returns></returns>
        public WhereCriteria<T> IsNotNull()
        {
            return _nullableCriterion.IsNotNull();
        }

        /// <summary>
        /// The property's value must be null
        /// </summary>
        /// <returns></returns>
        public WhereCriteria<T> IsNull()
        {
            return _nullableCriterion.IsNull();
        }

        /// <summary>
        /// The property's value must start with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> StartsWith(string value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.StartsWith,
                    Value = value
                }
            });

            return _where;
        }
    }
}
