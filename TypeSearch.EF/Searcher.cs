using System;
using System.Linq;

namespace TypeSearch.EF
{
    public class Searcher<T> : TypeSearch.Searcher<T>
        where T : class
    {
        public Searcher(IQueryable<T> dataSet) : base(dataSet, new PredicateFactory())
        {
        }
    }
}
