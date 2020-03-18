
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Criterion which describes how a field should be filtered
    /// </summary>
    public class RangeCriterion : BaseCriterion
    {
        /// <summary>
        /// Start value
        /// </summary>
        public object StartValue { get; set; }

        /// <summary>
        /// End value
        /// </summary>
        public object EndValue { get; set; }

        /// <summary>
        /// Operator
        /// </summary>
        public RangeOperator Operator { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{this.Name} {this.Operator} {this.StartValue} AND {this.EndValue}";
        }
    }
}
