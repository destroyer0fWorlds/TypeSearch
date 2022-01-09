using System;
using System.Collections.Generic;
using System.Linq;
using TypeSearch.Criteria;

namespace TypeSearch
{
    class WherePredicate<T>
        where T : class
    {
        public Dictionary<string, object> Params { get; private set; }

        public string Predicate { get; private set; }

        public bool Exists => this.Predicate != null;

        private readonly IPredicateFactory _predicateFactory;
        private readonly ICriterionFormatter<T> _criterionFormatter;

        public WherePredicate(IPredicateFactory predicateFactory, ICriterionFormatter<T> criterionFormatter)
        {
            _predicateFactory = predicateFactory;
            _criterionFormatter = criterionFormatter;
            this.Params = new Dictionary<string, object>();
            this.Predicate = null;
        }

        public void Create(List<CriteriaContainer<T>> whereCriteria)
        {
            this.Predicate = this.Recurse(whereCriteria);
        }

        private string Recurse(List<CriteriaContainer<T>> whereCriteria)
        {
            // Validate the input
            if (whereCriteria == null || !whereCriteria.Any()) { return null; }

            // Build the where
            var iteration = 0;
            var conditions = new List<string>();
            foreach (var whereCriterion in whereCriteria)
            {
                if (iteration > 0)
                {
                    // Apply logical separator i.e. [x] AND [y]
                    var logicOperator = whereCriterion.Operator.ToString();
                    conditions.Add(logicOperator);
                }

                var conditionCount = new[] { whereCriterion.HasNestedCriteria, whereCriterion.HasRangeCriterion, whereCriterion.HasSingleCriterion }.Count(i => i == true);
                if (conditionCount > 1)
                {
                    // This is not possible using the .Where(), .And(), and .Or() methods. It is only possible by manipulating the objects directly.
                    throw new NotSupportedException("Too many conditions supplied. Specify a single type per condition (single, range, or nested).");
                }

                if (whereCriterion.HasSingleCriterion)
                {
                    // Single
                    var singleCriterion = this.ParseSingleCriterion(whereCriterion.SingleCriterion);
                    conditions.Add($"({singleCriterion})");
                }
                else if (whereCriterion.HasRangeCriterion)
                {
                    // Range
                    var rangeCriterion = this.ParseRangeCriterion(whereCriterion.RangeCriterion);
                    conditions.Add($"({rangeCriterion})");
                }
                else if (whereCriterion.HasNestedCriteria)
                {
                    // Sub criteria
                    var subCriteria = this.Recurse(whereCriterion.NestedFilter.Criteria);
                    conditions.Add($"({subCriteria})");
                }

                iteration++;
            }

            return string.Join(" ", conditions);
        }

        private string ParseSingleCriterion(SingleCriterion<T> singleCriterion)
        {
            var name = singleCriterion.Name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(SingleCriterion<T>.Name), "Property or column name cannot be null or empty.");
            }

            // Escape the names and parameterize the values
            var valueParam = _criterionFormatter.GetParameterizedValue(singleCriterion);
            var nameParam = _criterionFormatter.GetParameterizedName(singleCriterion);

            this.Params.Add(valueParam.Key, valueParam.Value);
            var predicate = _predicateFactory.Create(nameParam, valueParam.Key, singleCriterion.Operator);

            // Special logic for handling collections
            var collectionName = singleCriterion.CollectionName;
            if (!string.IsNullOrWhiteSpace(collectionName))
            {
                var collectionNameParam = _criterionFormatter.GetParameterizedCollectionName(singleCriterion);
                predicate = $"{collectionNameParam}.Any({predicate})";
            }

            return predicate;
        }

        private string ParseRangeCriterion(RangeCriterion rangeCriterion)
        {
            var name = rangeCriterion.Name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(RangeCriterion.Name), "Property or column name cannot be null or empty.");
            }

            // Escape the names and parameterize the values
            var startValueParam = _criterionFormatter.GetParameterizedStartValue(rangeCriterion);
            this.Params.Add(startValueParam.Key, startValueParam.Value);

            var endValueParam = _criterionFormatter.GetParameterizedEndValue(rangeCriterion);
            this.Params.Add(endValueParam.Key, endValueParam.Value);

            var nameParam = _criterionFormatter.GetParameterizedName(rangeCriterion);

            var predicate = _predicateFactory.Create(nameParam, startValueParam.Key, endValueParam.Key, rangeCriterion.Operator);

            // Speacl logic for handling collections
            var collectionName = rangeCriterion.CollectionName;
            if (!string.IsNullOrWhiteSpace(collectionName))
            {
                var collectionNameParam = _criterionFormatter.GetParameterizedCollectionName(rangeCriterion);
                predicate = $"{collectionNameParam}.Any({predicate})";
            }

            return predicate;
        }
    }
}
