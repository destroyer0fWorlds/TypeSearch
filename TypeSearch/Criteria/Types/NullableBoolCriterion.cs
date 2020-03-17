using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Exposes nullable bool specific operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NullableBoolCriterion<T> : ObjectCriterion<T, bool?>, INullableCriterion<T>, IBoolCriterion<T>, IStringCriterion<T>
        where T : class
    {
        private readonly BoolCriterion<T> _boolCriterion;
        private readonly NullableCriterion<T, bool?> _nullableCriterion;
        private readonly StringCriterion<T> _stringCriterion;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableBoolCriterion{T}"/> class
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableBoolCriterion(string name, LogicalOperator @operator, WhereCriteria<T> where) : base(name, @operator, where)
        {
            _nullableCriterion = new NullableCriterion<T, bool?>(name, @operator, where);
            _boolCriterion = new BoolCriterion<T>(name, @operator, where);
            _stringCriterion = new StringCriterion<T>(name, @operator, where);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableBoolCriterion{T}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableBoolCriterion(string collectionName, string name, LogicalOperator @operator, WhereCriteria<T> where) : base(collectionName, name, @operator, where)
        {
            _nullableCriterion = new NullableCriterion<T, bool?>(name, @operator, where);
            _boolCriterion = new BoolCriterion<T>(name, @operator, where);
            _stringCriterion = new StringCriterion<T>(name, @operator, where);
        }

        /// <summary>
        /// The property's value must be false
        /// </summary>
        /// <returns></returns>
        public WhereCriteria<T> IsFalse()
        {
            return _boolCriterion.IsFalse();
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
        /// The property's value must be true
        /// </summary>
        /// <returns></returns>
        public WhereCriteria<T> IsTrue()
        {
            return _boolCriterion.IsTrue();
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
