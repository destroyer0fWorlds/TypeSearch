
namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to numeric types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class NumberOperation<T, TResult> : StringOperation<T, TResult>, INumberOperation<T, TResult>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public NumberOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(propertyName, @operator, filter)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public NumberOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(collectionName, propertyName, @operator, filter)
        {

        }

        /// <summary>
        /// The property's value must be between the given values (inclusive)
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        public FilterCriteria<T> Between(TResult startValue, TResult endValue)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateBetweenCriteria(startValue, endValue));
            return this.Filter;
        }

        /// <summary>
        /// The property's value must be greater than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> GreaterThan(TResult value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateGreaterThanCriteria(value));
            return this.Filter;
        }

        /// <summary>
        /// The property's value must be greater than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> GreaterThanOrEqualTo(TResult value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateGreaterThanOrEqualToCriteria(value));
            return this.Filter;
        }

        /// <summary>
        /// The property's value must be less than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> LessThan(TResult value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateLessThanCriteria(value));
            return this.Filter;
        }

        /// <summary>
        /// The property's value must be less than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> LessThanOrEqualTo(TResult value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateLessThanOrEqualToCriteria(value));
            return this.Filter;
        }

        /// <summary>
        /// The property's value must not be between the given values (exclusive)
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        public FilterCriteria<T> NotBetween(TResult startValue, TResult endValue)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateNotBetweenCriteria(startValue, endValue));
            return this.Filter;
        }
    }
}
