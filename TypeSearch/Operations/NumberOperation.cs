using TypeSearch.Criteria;

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
        /// <param name="where">Parent filter criteria</param>
        public NumberOperation(string propertyName, LogicalOperator @operator, WhereCriteria<T> where) : base(propertyName, @operator, where)
        {

        }

        /// <summary>
        /// The property's value must be between the given values (inclusive)
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        public WhereCriteria<T> Between(TResult startValue, TResult endValue)
        {
            this.Where.Criteria.Add(this.CreateBetweenCriteria(startValue, endValue));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property between start and end
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateBetweenCriteria(TResult startValue, TResult endValue)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                RangeCriterion = new RangeCriterion()
                {
                    Name = this.PropertyName,
                    Operator = RangeOperator.Between,
                    StartValue = startValue,
                    EndValue = endValue
                }
            };
        }

        /// <summary>
        /// The property's value must be greater than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> GreaterThan(TResult value)
        {
            this.Where.Criteria.Add(this.CreateGreaterThanCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property > value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateGreaterThanCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.GreaterThan,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must be greater than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> GreaterThanOrEqualTo(TResult value)
        {
            this.Where.Criteria.Add(this.CreateGreaterThanOrEqualToCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property >= value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateGreaterThanOrEqualToCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.GreaterThanOrEqualTo,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must be less than the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> LessThan(TResult value)
        {
            this.Where.Criteria.Add(this.CreateLessThanCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property &lt; value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateLessThanCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.LessThan,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must be less than or equal to the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereCriteria<T> LessThanOrEqualTo(TResult value)
        {
            this.Where.Criteria.Add(this.CreateLessThanOrEqualToCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property &lt;= value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateLessThanOrEqualToCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.LessThanOrEqualTo,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must not be between the given values (exclusive)
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        public WhereCriteria<T> NotBetween(TResult startValue, TResult endValue)
        {
            this.Where.Criteria.Add(this.CreateNotBetweenCriteria(startValue, endValue));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property not between start and end
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateNotBetweenCriteria(TResult startValue, TResult endValue)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                RangeCriterion = new RangeCriterion()
                {
                    Name = this.PropertyName,
                    Operator = RangeOperator.NotBetween,
                    StartValue = startValue,
                    EndValue = endValue
                }
            };
        }
    }
}
