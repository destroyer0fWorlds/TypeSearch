using System;
using System.Collections.Generic;
using System.Linq;
using TypeSearch.Criteria;

namespace TypeSearch
{
    class SortPredicate<T>
        where T : class
    {
        public string Predicate { get; private set; }

        public bool Exists => this.Predicate != null;

        private readonly ICriterionFormatter<T> _criterionFormatter;

        public SortPredicate(ICriterionFormatter<T> criterionFormatter)
        {
            _criterionFormatter = criterionFormatter;
            this.Predicate = null;
        }

        public void Create(HashSet<SortCriterion> sortCriteria)
        {
            this.Predicate = this.Recurse(sortCriteria);
        }

        private string Recurse(HashSet<SortCriterion> sortCriteria)
        {
            // Validate the input
            if (sortCriteria == null || !sortCriteria.Any()) { return null; }

            // Build the sort
            var conditions = new List<string>();
            foreach (var sortCriterion in sortCriteria)
            {
                var name = sortCriterion.Name;
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException(nameof(SortCriterion.Name), "Property or column name cannot be null or empty.");
                }

                var nameParam = _criterionFormatter.GetParameterizedName(sortCriterion);
                var direction = sortCriterion.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
                conditions.Add($"{nameParam} {direction}");
            }

            return string.Join(", ", conditions);
        }
    }
}
