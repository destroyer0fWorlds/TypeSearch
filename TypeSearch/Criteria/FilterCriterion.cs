
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Represents the most basic structure of a criterion
    /// </summary>
    public abstract class FilterCriterion
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection property name
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterCriterion"/> class
        /// </summary>
        public FilterCriterion()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterCriterion"/> class with the given property name
        /// </summary>
        /// <param name="name"></param>
        public FilterCriterion(string name) {
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterCriterion"/> class with the given collection and property name
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="name"></param>
        public FilterCriterion(string collectionName, string name)
        {
            this.CollectionName = collectionName;
            this.Name = name;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(this.CollectionName))
            {
                return $"{this.CollectionName}.{this.Name}";
            }
            return this.Name;
        }
    }
}
