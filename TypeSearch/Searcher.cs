using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
    public abstract class Searcher<T> 
        where T : class
    {
        protected IQueryable<T> _dataSet;
        protected Dictionary<string, object> _preParams;
        protected Dictionary<string, object> _whereParams;

        protected ParsingConfig ParsingConfig { get; set; }

        protected IPredicateFactory PredicateFactory { get; set; }

        protected ICriterionFormatter<T> CriterionFormatter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Searcher{T}"/> class
        /// </summary>
        /// <param name="dataSet">Dataset to search</param>
        public Searcher(IQueryable<T> dataSet)
        {
            _dataSet = dataSet;
            _preParams = new Dictionary<string, object>();
            _whereParams = new Dictionary<string, object>();
            this.ParsingConfig = ParsingConfig.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Searcher{T}"/> class
        /// </summary>
        /// <param name="dataSet">Dataset to search</param>
        /// <param name="parsingConfig"></param>
        /// <param name="predicateFactory">Custom predicate factory</param>
        /// <param name="criterionFormatter"></param>
        public Searcher(IQueryable<T> dataSet,
            ParsingConfig parsingConfig,
            IPredicateFactory predicateFactory, 
            ICriterionFormatter<T> criterionFormatter)
        {
            _dataSet = dataSet;
            _preParams = new Dictionary<string, object>();
            _whereParams = new Dictionary<string, object>();

            this.ParsingConfig = parsingConfig;
            this.PredicateFactory = predicateFactory;
            this.CriterionFormatter = criterionFormatter;
        }

        /// <summary>
        /// Execute the search as defined by the supplied definition
        /// </summary>
        /// <param name="searchDefinition">Search definition</param>
        /// <returns></returns>
        public virtual SearchResult<T> Search(SearchDefinition<T> searchDefinition)
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
                object[] parameters = _preParams.Values.ToArray();
                _dataSet = _dataSet.Where(this.ParsingConfig, prePredicate, parameters);

                // Clear the parameters for the next filter
                _whereParams = new Dictionary<string, object>();
                this.CriterionFormatter.ResetCount();
            }

            int totalRecordCount = _dataSet.Count();

            // Filter
            var wherePredicate = this.CreateWherePredicate(searchDefinition.Filter?.Criteria);
            if (wherePredicate != null)
            {
                object[] parameters = _whereParams.Values.ToArray();
                _dataSet = _dataSet.Where(this.ParsingConfig, wherePredicate, parameters);
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
        public virtual IEnumerable<T> Filter(SearchDefinition<T> searchDefinition)
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
                _dataSet = _dataSet.Where(this.ParsingConfig, prePredicate, parameters);
            }

            // Filter
            var wherePredicate = this.CreateWherePredicate(searchDefinition.Filter?.Criteria);
            if (wherePredicate != null)
            {
                object[] parameters = _whereParams.Values.ToArray();
                _dataSet = _dataSet.Where(this.ParsingConfig, wherePredicate, parameters);
            }

            return _dataSet.AsEnumerable<T>();
        }

        /// <summary>
        /// Create filter criteria predicate
        /// </summary>
        /// <param name="whereCriteria">Where criteria</param>
        /// <returns></returns>
        protected virtual string CreateWherePredicate(List<CriteriaContainer<T>> whereCriteria)
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
                    var subCriteria = this.CreateWherePredicate(whereCriterion.NestedFilter.Criteria);
                    conditions.Add($"({subCriteria})");
                }

                iteration++;
            }

            return string.Join(" ", conditions);
        }

        /// <summary>
        /// Parse a criterion which represents a single value
        /// </summary>
        /// <param name="singleCriterion">Single field/value criterion</param>
        /// <returns></returns>
        protected virtual string ParseSingleCriterion(SingleCriterion<T> singleCriterion)
        {
            var name = singleCriterion.Name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(SingleCriterion<T>.Name), "Property or column name cannot be null or empty.");
            }

            // Escape the names and parameterize the values
            var valueParam = this.CriterionFormatter.GetParameterizedValue(singleCriterion);
            var nameParam = this.CriterionFormatter.GetParameterizedName(singleCriterion);

            _whereParams.Add(valueParam.Key, valueParam.Value);
            var predicate = this.PredicateFactory.Create(nameParam, valueParam.Key, singleCriterion.Operator);

            // Special logic for handling collections
            var collectionName = singleCriterion.CollectionName;
            if (!string.IsNullOrWhiteSpace(collectionName))
            {
                var collectionNameParam = this.CriterionFormatter.GetParameterizedCollectionName(singleCriterion);
                predicate = $"{collectionNameParam}.Any({predicate})";
            }

            return predicate;
        }

        /// <summary>
        /// Parse a criterion which represents a range of values
        /// </summary>
        /// <param name="rangeCriterion">Range of value criteria</param>
        /// <returns></returns>
        protected virtual string ParseRangeCriterion(RangeCriterion rangeCriterion)
        {
            var name = rangeCriterion.Name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(RangeCriterion.Name), "Property or column name cannot be null or empty.");
            }

            // Escape the names and parameterize the values
            var startValueParam = this.CriterionFormatter.GetParameterizedStartValue(rangeCriterion);
            _whereParams.Add(startValueParam.Key, startValueParam.Value);

            var endValueParam = this.CriterionFormatter.GetParameterizedEndValue(rangeCriterion);
            _whereParams.Add(endValueParam.Key, endValueParam.Value);

            var nameParam = this.CriterionFormatter.GetParameterizedName(rangeCriterion);

            var predicate = this.PredicateFactory.Create(nameParam, startValueParam.Key, endValueParam.Key, rangeCriterion.Operator);

            // Speacl logic for handling collections
            var collectionName = rangeCriterion.CollectionName;
            if (!string.IsNullOrWhiteSpace(collectionName))
            {
                var collectionNameParam = this.CriterionFormatter.GetParameterizedCollectionName(rangeCriterion);
                predicate = $"{collectionNameParam}.Any({predicate})";
            }

            return predicate;
        }

        /// <summary>
        /// Create sort criteria predicate
        /// </summary>
        /// <param name="sortCriteria">Sort criteria</param>
        /// <returns></returns>
        protected virtual string CreateSortPredicate(HashSet<SortCriterion> sortCriteria)
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

                var nameParam = this.CriterionFormatter.GetParameterizedName(sortCriterion);
                var direction = sortCriterion.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
                conditions.Add($"{nameParam} {direction}");
            }

            return string.Join(", ", conditions);
        }

        /// <summary>
        /// Page the dataset
        /// </summary>
        /// <param name="pageNumber">Zero indexed page number</param>
        /// <param name="recordsPerPage">Number of records to return per page</param>
        /// <returns></returns>
        protected virtual IQueryable<T> Page(int pageNumber, int recordsPerPage)
        {
            // Skip
            int skip = pageNumber * recordsPerPage;
            _dataSet = _dataSet.Skip(skip);

            // Take
            _dataSet = _dataSet.Take(recordsPerPage);

            return _dataSet;
        }
    }
}
