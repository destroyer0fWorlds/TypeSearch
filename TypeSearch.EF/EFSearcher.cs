using System;
using System.Linq;

namespace TypeSearch.EF
{
    public class EFSearcher<T> : Searcher<T>
        where T : class
    {
        public EFSearcher(IQueryable<T> dataSet) : base(dataSet, new PredicateFactory())
        {
        }
    }
}
