using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TypeSearch.Criteria;

namespace TypeSearch
{
    /// <summary>
    /// Sort (order by) criteria
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortCriteria<T>
        where T : class
    {
        /// <summary>
        /// Sort criteria collection
        /// </summary>
        public HashSet<SortCriterion> Criteria { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortCriteria{T}"/> class
        /// </summary>
        public SortCriteria()
        {
            this.Criteria = new HashSet<SortCriterion>();
        }

        /// <summary>
        /// Sort in ascending order
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp"></param>
        /// <returns></returns>
        public SortCriteria<T> AscendingBy<TResult>(Expression<Func<T, TResult>> exp)
        {
            this.Criteria.Add(new SortCriterion()
            {
                Name = ExpressionHelper.GetName(exp),
                SortDirection = SortDirection.Ascending
            });
            return this;
        }

        /// <summary>
        /// Sort in descending order
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp"></param>
        /// <returns></returns>
        public SortCriteria<T> DescendingBy<TResult>(Expression<Func<T, TResult>> exp)
        {
            this.Criteria.Add(new SortCriterion()
            {
                Name = ExpressionHelper.GetName(exp),
                SortDirection = SortDirection.Descending
            });
            return this;
        }
    }
}
