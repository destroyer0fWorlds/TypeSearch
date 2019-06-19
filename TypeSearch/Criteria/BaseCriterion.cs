using System;
using System.Collections.Generic;
using System.Text;

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
        /// Initializes a new instance of the <see cref="BaseCriterion"/> class
        /// </summary>
        public BaseCriterion()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCriterion"/> class with the given name
        /// </summary>
        /// <param name="name"></param>
        public BaseCriterion(string name) {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
