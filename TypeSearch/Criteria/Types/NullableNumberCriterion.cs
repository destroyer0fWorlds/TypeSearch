using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Exposes nullable number specific operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class NullableNumberCriterion<T, TResult> : ObjectCriterion<T, TResult>, INullableCriterion<T>, INumberCriterion<T, TResult>, IStringCriterion<T>
        where T : class
    {
        private readonly NumberCriterion<T, TResult> _numberCriterion;
        private readonly NullableCriterion<T, TResult> _nullableCriterion;
        private readonly StringCriterion<T> _stringCriterion;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableNumberCriterion{T, TResult}"/> class
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableNumberCriterion(string name, LogicalOperator @operator, WhereCriteria<T> where) : base(name, @operator, where)
        {
            _nullableCriterion = new NullableCriterion<T, TResult>(name, @operator, where);
            _numberCriterion = new NumberCriterion<T, TResult>(name, @operator, where);
            _stringCriterion = new StringCriterion<T>(name, @operator, where);
        }

        /// <summary>
        /// The property's value must be between the given values (inclusive)
        /// </summary>
        /// <param name="valueStart"></param>
        /// <param name="valueEnd"></param>
        /// <returns></returns>
        public WhereCriteria<T> Between(TResult valueStart, TResult valueEnd)
        {
            return _numberCriterion.Between(valueStart, valueEnd);
        }

        /// <summary>
        /// The property's value must be greater than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> GreaterThan(TResult value)
        {
            return _numberCriterion.GreaterThan(value);
        }

        /// <summary>
        /// The property's value must be greater than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> GreaterThanOrEqualTo(TResult value)
        {
            return _numberCriterion.GreaterThanOrEqualTo(value);
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
        /// The property's value must be less than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> LessThan(TResult value)
        {
            return _numberCriterion.LessThan(value);
        }

        /// <summary>
        /// The property's value must be less than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> LessThanOrEqualTo(TResult value)
        {
            return _numberCriterion.LessThanOrEqualTo(value);
        }

        /// <summary>
        /// The property's value must not be between the given values (exclusive)
        /// </summary>
        /// <param name="valueStart"></param>
        /// <param name="valueEnd"></param>
        /// <returns></returns>
        public WhereCriteria<T> NotBetween(TResult valueStart, TResult valueEnd)
        {
            return _numberCriterion.NotBetween(valueStart, valueEnd);
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
