
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Criterion which describes how a field should be sorted
    /// </summary>
    public class SortCriterion
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sort direction
        /// </summary>
        public SortDirection SortDirection { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{this.Name} {this.SortDirection}";
        }
    }
}
