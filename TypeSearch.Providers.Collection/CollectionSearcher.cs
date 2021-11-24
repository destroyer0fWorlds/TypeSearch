using System;
using System.Linq;

namespace TypeSearch.Providers.Collection
{
    public class CollectionSearcher<T> : Searcher<T>
        where T : class
    {
        public CollectionSearcher(IQueryable<T> dataSet) : base(dataSet)
        {
            this.PredicateFactory = new PredicateFactory();
            this.CriterionFormatter = new CollectionCriterionFormatter<T>();
        }
    }
}
