
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Criterion which describes how a field should be filtered
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleCriterion<T> : FilterCriterion
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

        /// <inheritdoc />
        public override string ToString()
        {
            var name = this.Name;
            if (!string.IsNullOrWhiteSpace(this.CollectionName)) { name = $"{this.CollectionName}.{this.Name}"; }
            return $"{name} {this.Operator} {this.Value}";
        }
    }
}
