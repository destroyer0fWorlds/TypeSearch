
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Criterion which describes how a field should be filtered
    /// </summary>
    public class RangeEnumerableCriterion : RangeCriterion
    {
        /// <summary>
        /// Collection property name
        /// </summary>
        public string CollectionName { get; set; }

        public override string ToString()
        {
            return $"{this.CollectionName}.{this.Name} {this.Operator} {this.StartValue} AND {this.EndValue}";
        }
    }
}
