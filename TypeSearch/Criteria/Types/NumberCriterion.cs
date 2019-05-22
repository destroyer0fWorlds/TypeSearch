using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Exposes number specific operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class NumberCriterion<T, TResult> : ObjectCriterion<T, TResult>, INumberCriterion<T, TResult>, IStringCriterion<T>
        where T : class
    {
        private readonly StringCriterion<T> _stringCriterion;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberCriterion{T, TResult}"/> class
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NumberCriterion(string name, LogicalOperator @operator, WhereCriteria<T> where) : base(name, @operator, where)
        {
            _stringCriterion = new StringCriterion<T>(name, @operator, where);
        }

        /// <summary>
        /// The property's value must be between the given values (inclusive)
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        public WhereCriteria<T> Between(TResult startValue, TResult endValue)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                RangeCriterion = new RangeCriterion()
                {
                    Name = this.Name,
                    Operator = RangeOperator.Between,
                    StartValue = startValue,
                    EndValue = endValue
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must be greater than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> GreaterThan(TResult value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.GreaterThan,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must be greater than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> GreaterThanOrEqualTo(TResult value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.GreaterThanOrEqualTo,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must be less than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> LessThan(TResult value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.LessThan,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must be less than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> LessThanOrEqualTo(TResult value)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.LessThanOrEqualTo,
                    Value = value
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must not be between the given values (exclusive)
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        public WhereCriteria<T> NotBetween(TResult startValue, TResult endValue)
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                RangeCriterion = new RangeCriterion()
                {
                    Name = this.Name,
                    Operator = RangeOperator.NotBetween,
                    StartValue = startValue,
                    EndValue = endValue
                }
            });

            return _where;
        }

        /// <summary>
        /// The property's value must contain the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> Contains(string value)
        {
            return _stringCriterion.Contains(value);
        }

        /// <summary>
        /// The property's value must not contain the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> DoesNotContain(string value)
        {
            return _stringCriterion.DoesNotContain(value);
        }

        /// <summary>
        /// The property's value must not end with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> DoesNotEndWith(string value)
        {
            return _stringCriterion.DoesNotEndWith(value);
        }

        /// <summary>
        /// The property's value must not start with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> DoesNotStartWith(string value)
        {
            return _stringCriterion.DoesNotStartWith(value);
        }

        /// <summary>
        /// The property's value must end with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> EndsWith(string value)
        {
            return _stringCriterion.EndsWith(value);
        }

        /// <summary>
        /// The property's value must start with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> StartsWith(string value)
        {
            return _stringCriterion.StartsWith(value);
        }
    }
}
