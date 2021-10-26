using System;
using TypeSearch.Criteria;

namespace TypeSearch
{
    /// <summary>
    /// Factory responsible for producing predicates
    /// </summary>
    public interface IPredicateFactory
    {
        /// <summary>
        /// Create an operation specific predicate
        /// </summary>
        /// <param name="name">Parameterized property name</param>
        /// <param name="value">Parameterized value</param>
        /// <param name="operator">Operator</param>
        /// <returns></returns>
        string Create(string name, string value, SingleOperator @operator);

        /// <summary>
        /// Create an operation specific predicate
        /// </summary>
        /// <param name="name">Parameterized property name</param>
        /// <param name="startValue">Parameterized start value</param>
        /// <param name="endValue">Parameterized end value</param>
        /// <param name="operator">Operator</param>
        /// <returns></returns>
        string Create(string name, string startValue, string endValue, RangeOperator @operator);
    }
}
