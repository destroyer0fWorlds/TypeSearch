using TypeSearch.Criteria;

namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to string types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class StringOperation<T, TResult> : ObjectOperation<T, TResult>, IStringOperation<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public StringOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> where) : base(propertyName, @operator, where)
        {
            
        }

        /// <summary>
        /// The property's value must contain the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> Contains(string value)
        {
            this.Where.Criteria.Add(this.CreateContainsCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property contains value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateContainsCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.Like,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must not contain the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> DoesNotContain(string value)
        {
            this.Where.Criteria.Add(this.CreateNotContainsCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property not contains value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateNotContainsCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.NotLike,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must end with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> EndsWith(string value)
        {
            this.Where.Criteria.Add(this.CreateEndsWithCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property ends with value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateEndsWithCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.EndsWith,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must not end with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> DoesNotEndWith(string value)
        {
            this.Where.Criteria.Add(this.CreateNotEndsWithCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property not ends with value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateNotEndsWithCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.DoesNotEndWith,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must start with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> StartsWith(string value)
        {
            this.Where.Criteria.Add(this.CreateStartsWithCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property starts with value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateStartsWithCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.StartsWith,
                    Value = value
                }
            };
        }

        /// <summary>
        /// The property's value must not start with the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterCriteria<T> DoesNotStartWith(string value)
        {
            this.Where.Criteria.Add(this.CreateNotStartsWithCriteria(value));
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property not starts with value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateNotStartsWithCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.DoesNotStartWith,
                    Value = value
                }
            };
        }
    }
}
