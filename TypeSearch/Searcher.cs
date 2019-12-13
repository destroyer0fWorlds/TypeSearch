using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using TypeSearch.Criteria;

namespace TypeSearch
{
    /// <summary>
    /// Searcher
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// For reference: https://github.com/StefH/System.Linq.Dynamic.Core/wiki/Dynamic-Expressions
    /// </remarks>
    public class Searcher<T> 
        where T : class
    {
        private IQueryable<T> _dataSet;
        private Dictionary<string, object> _preParams;
        private Dictionary<string, object> _whereParams;

        /// <summary>
        /// Initializes a new instance of the <see cref="Searcher{T}"/> class
        /// </summary>
        /// <param name="dataSet">Dataset to search</param>
        public Searcher(IQueryable<T> dataSet)
        {
            _dataSet = dataSet;
            _preParams = new Dictionary<string, object>();
            _whereParams = new Dictionary<string, object>();
        }

        /// <summary>
        /// Execute the search as defined by the supplied definition
        /// </summary>
        /// <param name="searchDefinition">Search definition</param>
        /// <returns></returns>
        public SearchResult<T> Search(SearchDefinition<T> searchDefinition)
        {
            // Sanitize the input
            if (searchDefinition == null) { searchDefinition = new SearchDefinition<T>(); }
            var page = searchDefinition.Page;
            var recordsPerPage = searchDefinition.RecordsPerPage;

            // Pre-filter
            var prePredicate = this.CreateWherePredicate(searchDefinition.PreFilter?.Criteria);
            if (prePredicate != null)
            {
                _preParams = new Dictionary<string, object>(_whereParams);
                _whereParams = new Dictionary<string, object>();
                object[] parameters = _preParams.Values.ToArray();
                _dataSet = _dataSet.Where(prePredicate, parameters);
            }

            int totalRecordCount = _dataSet.Count();

            // Filter
            var wherePredicate = this.CreateWherePredicate(searchDefinition.Filter?.Criteria);
            if (wherePredicate != null)
            {
                object[] parameters = _whereParams.Values.ToArray();
                _dataSet = _dataSet.Where(wherePredicate, parameters);
            }

            int filteredRecordCount = _dataSet.Count();
            if (filteredRecordCount > 0)
            {
                // Sort
                var sortPredicate = this.CreateSortPredicate(searchDefinition.Sort?.Criteria);
                if (sortPredicate != null)
                {
                    _dataSet = _dataSet.OrderBy(sortPredicate);
                }

                //Page
                if (page.HasValue && recordsPerPage.HasValue)
                {
                    _dataSet = this.Page(page.Value, recordsPerPage.Value);
                }
            }
            
            return new SearchResult<T>()
            {
                Page = page,
                RecordsPerPage = recordsPerPage,
                ResultSet = _dataSet.ToList(),
                TotalRecordCount = totalRecordCount,
                FilteredRecordCount = filteredRecordCount
            };
        }

        /// <summary>
        /// Executes the filter as defined by the supplied definition
        /// </summary>
        /// <param name="searchDefinition">Search definition</param>
        /// <returns></returns>
        public IEnumerable<T> Filter(SearchDefinition<T> searchDefinition)
        {
            // Sanitize the input
            if (searchDefinition == null) { searchDefinition = new SearchDefinition<T>(); }

            // Pre-filter
            var prePredicate = this.CreateWherePredicate(searchDefinition.PreFilter?.Criteria);
            if (prePredicate != null)
            {
                _preParams = new Dictionary<string, object>(_whereParams);
                _whereParams = new Dictionary<string, object>();
                object[] parameters = _preParams.Values.ToArray();
                _dataSet = _dataSet.Where(prePredicate, parameters);
            }

            // Filter
            var wherePredicate = this.CreateWherePredicate(searchDefinition.Filter?.Criteria);
            if (wherePredicate != null)
            {
                object[] parameters = _whereParams.Values.ToArray();
                _dataSet = _dataSet.Where(wherePredicate, parameters);
            }

            return _dataSet.AsEnumerable<T>();
        }

        /// <summary>
        /// Create filter criteria predicate
        /// </summary>
        /// <param name="whereCriteria">Where criteria</param>
        /// <returns></returns>
        private string CreateWherePredicate(List<CriteriaContainer<T>> whereCriteria)
        {
            // Validate the input
            if (whereCriteria == null || !whereCriteria.Any()) { return null; }

            // Build the where
            var iteration = 0;
            var conditions = new List<string>();
            foreach (var whereCriterion in whereCriteria)
            {
                if (iteration++ > 0)
                {
                    var logicOperator = whereCriterion.Operator.ToString();
                    conditions.Add(logicOperator);
                }

                var conditionCount = new[] {
                    whereCriterion.HasNestedCriteria,
                    whereCriterion.HasRangeCriterion,
                    whereCriterion.HasSingleCriterion
                }.Count(i => i);
                if (conditionCount > 1)
                {
                    throw new NotSupportedException("Too many conditions supplied. Specify a single criterion per condition (single, range, or nested).");
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
                    var subCriteria = this.CreateWherePredicate(whereCriterion.CriteriaCollection.Criteria);
                    conditions.Add($"({subCriteria})");
                }
            }

            return string.Join(" ", conditions);
        }

        /// <summary>
        /// Parse a criterion which represents a single value
        /// </summary>
        /// <param name="singleCriterion">Single field/value criterion</param>
        /// <returns></returns>
        private string ParseSingleCriterion(SingleCriterion<T> singleCriterion)
        {
            var name = singleCriterion.Name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(SingleCriterion<T>.Name), "Property or column name cannot be null or empty.");
            }

            // Parameterize the values in the form @0, @1, @2, etc.
            var valueParam = this.ParameterizeValue(singleCriterion.Value);
            var propertyNameParam = this.EscapePropertyName(name);

            var predicate = PredicateFactory.Create<T>(name, propertyNameParam, valueParam, singleCriterion.Operator);
            return predicate.Create();
        }

        /// <summary>
        /// Parse a criterion which represents a range of values
        /// </summary>
        /// <param name="rangeCriterion">Range of value criteria</param>
        /// <returns></returns>
        private string ParseRangeCriterion(RangeCriterion rangeCriterion)
        {
            var name = rangeCriterion.Name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(RangeCriterion.Name), "Property or column name cannot be null or empty.");
            }

            // Parameterize the values in the form @0, @1, @2, etc.
            var startValueParam = this.ParameterizeValue(rangeCriterion.StartValue);
            var endValueParam = this.ParameterizeValue(rangeCriterion.EndValue);
            var propertyNameParam = this.EscapePropertyName(name);

            switch (rangeCriterion.Operator)
            {
                case RangeOperator.Between:
                    return $"{propertyNameParam} >= {startValueParam} And {propertyNameParam} <= {endValueParam}";
                case RangeOperator.NotBetween:
                    return $"{propertyNameParam} < {startValueParam} Or {propertyNameParam} > {endValueParam}";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Create sort criteria predicate
        /// </summary>
        /// <param name="sortCriteria">Sort criteria</param>
        /// <returns></returns>
        private string CreateSortPredicate(HashSet<SortCriterion> sortCriteria)
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

                var propertyNameParam = this.EscapePropertyName(name);
                var direction = sortCriterion.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
                conditions.Add($"{propertyNameParam} {direction}");
            }

            return string.Join(", ", conditions);
        }

        /// <summary>
        /// Page the dataset
        /// </summary>
        /// <param name="pageNumber">Zero indexed page number</param>
        /// <param name="recordsPerPage">Number of records to return per page</param>
        /// <returns></returns>
        private IQueryable<T> Page(int pageNumber, int recordsPerPage)
        {
            // Skip
            int skip = pageNumber * recordsPerPage;
            _dataSet = _dataSet.Skip(skip);

            // Take
            _dataSet = _dataSet.Take(recordsPerPage);

            return _dataSet;
        }

        /// <summary>
        /// Parameterize the predicate value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string ParameterizeValue(object value)
        {
            var valueParam = $"@{_whereParams.Count}";
            _whereParams.Add(valueParam, value);
            return valueParam;
        }

        /// <summary>
        /// Escape property names to avoid conflicts
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private string EscapePropertyName(string propertyName)
        {
            return $"@{propertyName}";
        }
    }
}
