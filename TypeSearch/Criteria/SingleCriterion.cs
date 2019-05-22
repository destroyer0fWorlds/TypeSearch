using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria
{
    /// <summary>
    /// Criterion which describes how a field should be filtered
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleCriterion<T> : BaseCriterion
        where T : class
    {
        /// <summary>
        /// Value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Operator
        /// </summary>
        public SingleOperator Operator { get; set; }
    }
}
