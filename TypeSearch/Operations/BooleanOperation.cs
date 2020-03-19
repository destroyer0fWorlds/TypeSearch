using TypeSearch.Criteria;

namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to boolean types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class BooleanOperation<T, TResult> : StringOperation<T, TResult>, IBooleanOperation<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public BooleanOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> where) : base(propertyName, @operator, where)
        {

        }

        /// <summary>
        /// The property's value must be false
        /// </summary>
        /// <returns></returns>
        public FilterCriteria<T> IsFalse()
        {
            this.Where.Criteria.Add(this.CreateFalseCriteria());
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property == false
        /// </summary>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateFalseCriteria()
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.Equals,
                    Value = false
                }
            };
        }

        /// <summary>
        /// The property's value must be true
        /// </summary>
        /// <returns></returns>
        public FilterCriteria<T> IsTrue()
        {
            this.Where.Criteria.Add(this.CreateTrueCriteria());
            return this.Where;
        }

        /// <summary>
        /// Create a criteria that evaluates to: property == true
        /// </summary>
        /// <returns></returns>
        protected virtual CriteriaContainer<T> CreateTrueCriteria()
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.Equals,
                    Value = true
                }
            };
        }
    }
}
