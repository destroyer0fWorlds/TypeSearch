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
            int page = searchDefinition.Page.GetValueOrDefault(-1);
            int recordsPerPage = searchDefinition.RecordsPerPage.GetValueOrDefault(-1);

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

                // Page
                if (page < 0 || recordsPerPage < 0)
                {
                    page = 0;
                    recordsPerPage = 0;
                }
                else
                {
                    _dataSet = this.Page(page, recordsPerPage);
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

                if (whereCriterion.SingleCriterion != null)
                {
                    // Single
                    var singleCriterion = this.ParseSingleCriterion(whereCriterion.SingleCriterion);
                    conditions.Add($"({singleCriterion})");
                }
                else if (whereCriterion.RangeCriterion != null)
                {
                    // Range
                    var rangeCriterion = this.ParseRangeCriterion(whereCriterion.RangeCriterion);
                    conditions.Add($"({rangeCriterion})");
                }
                else if (whereCriterion.CriteriaCollection != null && whereCriterion.CriteriaCollection.Criteria != null)
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
            // For reference:
            // https://github.com/StefH/System.Linq.Dynamic.Core/wiki/Dynamic-Expressions

            // Parameterize the values in the form @0, @1, @2, etc.
            var name = singleCriterion.Name;
            var value = singleCriterion.Value;
            var paramName = $"@{_whereParams.Count}";
            _whereParams.Add(paramName, value);

            var type = typeof(T);
            var propertyInfo = type.GetProperty(name);
            if (propertyInfo == null) { throw new ArgumentException($"Invalid name '{name}'. No property or column exists with the given name.", nameof(SingleCriterion<T>.Name)); }
            var propertyType = propertyInfo.PropertyType;
            if (propertyType == typeof(string))
            {
                // String type
                switch (singleCriterion.Operator)
                {
                    case SingleOperator.StartsWith:
                        return $"({name} ?? string.Empty).StartsWith({paramName})";
                    case SingleOperator.EndsWith:
                        return $"({name} ?? string.Empty).EndsWith({paramName})";
                    case SingleOperator.Like:
                        return $"({name} ?? string.Empty).Contains({paramName})";
                    case SingleOperator.DoesNotStartWith:
                        return $"!({name} ?? string.Empty).StartsWith({paramName})";
                    case SingleOperator.DoesNotEndWith:
                        return $"!({name} ?? string.Empty).EndsWith({paramName})";
                    case SingleOperator.NotLike:
                        return $"!({name} ?? string.Empty).Contains({paramName})";
                }
            }
            else if (Nullable.GetUnderlyingType(propertyType) != null)
            {
                // Nullable type
                switch (singleCriterion.Operator)
                {
                    case SingleOperator.StartsWith:
                        return $"({name} == null ? string.Empty : {name}.ToString()).StartsWith({paramName})";
                    case SingleOperator.EndsWith:
                        return $"({name} == null ? string.Empty : {name}.ToString()).EndsWith({paramName})";
                    case SingleOperator.Like:
                        return $"({name} == null ? string.Empty : {name}.ToString()).Contains({paramName})";
                    case SingleOperator.DoesNotStartWith:
                        return $"!({name} == null ? string.Empty : {name}.ToString()).StartsWith({paramName})";
                    case SingleOperator.DoesNotEndWith:
                        return $"!({name} == null ? string.Empty : {name}.ToString()).EndsWith({paramName})";
                    case SingleOperator.NotLike:
                        return $"!({name} == null ? string.Empty : {name}.ToString()).Contains({paramName})";
                }
            }
            else
            {
                // Real type
                switch (singleCriterion.Operator)
                {
                    case SingleOperator.StartsWith:
                        return $"{name}.ToString().StartsWith({paramName})";
                    case SingleOperator.EndsWith:
                        return $"{name}.ToString().EndsWith({paramName})";
                    case SingleOperator.Like:
                        return $"{name}.ToString().Contains({paramName})";
                    case SingleOperator.DoesNotStartWith:
                        return $"!{name}.ToString().StartsWith({paramName})";
                    case SingleOperator.DoesNotEndWith:
                        return $"!{name}.ToString().EndsWith({paramName})";
                    case SingleOperator.NotLike:
                        return $"!{name}.ToString().Contains({paramName})";
                }
            }

            switch (singleCriterion.Operator)
            {
                case SingleOperator.Equals:
                    return $"{name} == {paramName}";
                case SingleOperator.NotEquals:
                    return $"{name} != {paramName}";
                case SingleOperator.GreaterThan:
                    return $"{name} > {paramName}";
                case SingleOperator.GreaterThanOrEqualTo:
                    return $"{name} >= {paramName}";
                case SingleOperator.LessThan:
                    return $"{name} < {paramName}";
                case SingleOperator.LessThanOrEqualTo:
                    return $"{name} <= {paramName}";
                case SingleOperator.IsNull:
                    return $"{name} == {paramName}";
                case SingleOperator.IsNotNull:
                    return $"{name} != {paramName}";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Parse a criterion which represents a range of values
        /// </summary>
        /// <param name="rangeCriterion">Range of value criteria</param>
        /// <returns></returns>
        private string ParseRangeCriterion(RangeCriterion rangeCriterion)
        {
            // For reference:
            // https://github.com/StefH/System.Linq.Dynamic.Core/wiki/Dynamic-Expressions

            // Parameterize the values in the form @0, @1, @2, etc.
            var name = rangeCriterion.Name;

            var startValue = rangeCriterion.StartValue;
            var startParamName = $"@{_whereParams.Count}";
            _whereParams.Add(startParamName, startValue);

            var endValue = rangeCriterion.EndValue;
            var endParamName = $"@{_whereParams.Count}";
            _whereParams.Add(endParamName, endValue);

            switch (rangeCriterion.Operator)
            {
                case RangeOperator.Between:
                    return $"{name} >= {startParamName} And {name} <= {endParamName}";
                case RangeOperator.NotBetween:
                    return $"{name} < {startParamName} Or {name} > {endParamName}";
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
            // For reference:
            // https://github.com/StefH/System.Linq.Dynamic.Core/wiki/Dynamic-Expressions

            // Validate the input
            if (sortCriteria == null || !sortCriteria.Any()) { return null; }

            // Build the sort
            var conditions = new List<string>();
            foreach (var sortCriterion in sortCriteria)
            {
                var name = sortCriterion.Name;
                var direction = sortCriterion.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
                conditions.Add($"{name} {direction}");
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
            // Validate the input
            if (pageNumber < 0) { return _dataSet; }
            if (recordsPerPage < 0) { return _dataSet; }

            // Skip
            int skip = pageNumber * recordsPerPage;
            _dataSet = _dataSet.Skip(skip);

            // Take
            _dataSet = _dataSet.Take(recordsPerPage);

            return _dataSet;
        }
    }
}
