using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Exposes the most basic level of operations available for any type of nullable criterion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class NullableCriterion<T, TResult> : ObjectCriterion<T, TResult>, INullableCriterion<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableCriterion{T, TResult}"/> class
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableCriterion(string name, LogicalOperator @operator, WhereCriteria<T> where) : base(name, @operator, where)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableCriterion{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="name">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableCriterion(string collectionName, string name, LogicalOperator @operator, WhereCriteria<T> where) : base(collectionName, name, @operator, where)
        {

        }

        /// <summary>
        /// The property's value must be null
        /// </summary>
        /// <returns></returns>
        public WhereCriteria<T> IsNull()
        {
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.IsNull
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
            _where.Criteria.Add(new CriteriaContainer<T>()
            {
                Operator = _operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.Name,
                    Operator = SingleOperator.IsNotNull
                }
            });

            return _where;
        }
    }
}
