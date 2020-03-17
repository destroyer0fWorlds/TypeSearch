
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Criterion which describes how a field should be filtered
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleEnumerableCriterion<T> : SingleCriterion<T>
        where T : class
    {
        /// <summary>
        /// Collection property name
        /// </summary>
        public string CollectionName { get; set; }
        
        public override string ToString()
        {
            return $"{this.CollectionName}.{this.Name} {this.Operator} {this.Value}";
        }
    }
}
