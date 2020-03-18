using TypeSearch.Criteria;

namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to nullable types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class NullableOperation<T, TResult> : ObjectOperation<T, TResult>, INullableOperation<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableOperation(string propertyName, LogicalOperator @operator, WhereCriteria<T> where) : base(propertyName, @operator, where)
        {

        }

        /// <summary>
        /// The property's value must be null
        /// </summary>
        /// <returns></returns>
        public WhereCriteria<T> IsNull()
        {
            this.Where.Criteria.Add(this.CreateNullCriteria());
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property is null
        /// </summary>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateNullCriteria()
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.IsNull
                }
            };
        }

        /// <summary>
        /// The property's value must not be null
        /// </summary>
        /// <returns></returns>
        public WhereCriteria<T> IsNotNull()
        {
            this.Where.Criteria.Add(this.CreateNotNullCriteria());
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property is not null
        /// </summary>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateNotNullCriteria()
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.IsNotNull
                }
            };
        }
    }
}
