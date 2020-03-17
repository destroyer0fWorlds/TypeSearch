
namespace TypeSearch.Criteria
{
    /// <summary>
    /// Represents the most basic structure of a criterion
    /// </summary>
    public abstract class BaseCriterion
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
        /// Initializes a new instance of the <see cref="BaseCriterion"/> class
        /// </summary>
        public BaseCriterion()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCriterion"/> class with the given property name
        /// </summary>
        /// <param name="name"></param>
        public BaseCriterion(string name) {
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCriterion"/> class with the given collection and property name
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="name"></param>
        public BaseCriterion(string collectionName, string name)
        {
            this.CollectionName = collectionName;
            this.Name = name;
        }

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
