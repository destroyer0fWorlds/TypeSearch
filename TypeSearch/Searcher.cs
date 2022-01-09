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
        /// <summary>
        /// The collection to search
        /// </summary>
        protected IQueryable<T> _dataSet;

        /// <summary>
        /// Dynamic Linq configuration
        /// </summary>
        protected ParsingConfig ParsingConfig { get; set; }

        /// <summary>
        /// Object responsible for generating valid predicate syntax
        /// </summary>
        protected IPredicateFactory PredicateFactory { get; set; }

        /// <summary>
        /// Object responsible for generating valid parameter names and values
        /// </summary>
        protected ICriterionFormatter<T> CriterionFormatter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Searcher{T}"/> class
        /// </summary>
        /// <param name="dataSet">Dataset to search</param>
        public Searcher(IQueryable<T> dataSet)
        {
            _dataSet = dataSet;
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
            var prePredicate = new WherePredicate<T>(this.PredicateFactory, this.CriterionFormatter);
            prePredicate.Create(searchDefinition.PreFilter?.Criteria);
            if (prePredicate.Exists)
            {
                _dataSet = _dataSet.Where(this.ParsingConfig, prePredicate.Predicate, prePredicate.Params);
                this.CriterionFormatter.ResetCount();
            }

            int totalRecordCount = _dataSet.Count();

            // Filter
            var wherePredicate = new WherePredicate<T>(this.PredicateFactory, this.CriterionFormatter);
            wherePredicate.Create(searchDefinition.Filter?.Criteria);
            if (wherePredicate.Exists)
            {
                _dataSet = _dataSet.Where(this.ParsingConfig, wherePredicate.Predicate, wherePredicate.Params);
                this.CriterionFormatter.ResetCount();
            }

            int filteredRecordCount = _dataSet.Count();
            if (filteredRecordCount > 0)
            {
                // Sort
                var sortPredicate = new SortPredicate<T>(this.CriterionFormatter);
                sortPredicate.Create(searchDefinition.Sort?.Criteria);
                if (sortPredicate.Exists)
                {
                    _dataSet = _dataSet.OrderBy(sortPredicate.Predicate);
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
            var prePredicate = new WherePredicate<T>(this.PredicateFactory, this.CriterionFormatter);
            prePredicate.Create(searchDefinition.PreFilter?.Criteria);
            if (prePredicate.Exists)
            {
                _dataSet = _dataSet.Where(this.ParsingConfig, prePredicate.Predicate, prePredicate.Params);
                this.CriterionFormatter.ResetCount();
            }

            // Filter
            var wherePredicate = new WherePredicate<T>(this.PredicateFactory, this.CriterionFormatter);
            wherePredicate.Create(searchDefinition.Filter?.Criteria);
            if (wherePredicate.Exists)
            {
                _dataSet = _dataSet.Where(this.ParsingConfig, wherePredicate.Predicate, wherePredicate.Params);
                this.CriterionFormatter.ResetCount();
            }

            return _dataSet.AsEnumerable<T>();
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
