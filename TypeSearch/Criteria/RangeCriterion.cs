
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Criterion which describes how a field should be filtered
    /// </summary>
    public class RangeCriterion : FilterCriterion
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
            var name = this.Name;
            if (!string.IsNullOrWhiteSpace(this.CollectionName)) { name = $"{this.CollectionName}.{this.Name}"; }
            return $"{name} {this.Operator} {this.StartValue} AND {this.EndValue}";
        }
    }
}
