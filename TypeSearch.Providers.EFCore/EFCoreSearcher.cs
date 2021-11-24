using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace TypeSearch.Providers.EFCore
{
    public class EFCoreSearcher<T> : Searcher<T>
        where T : class
    {
        public EFCoreSearcher(IQueryable<T> dataSet) : base(dataSet)
        {
            this.ParsingConfig = ParsingConfig.DefaultEFCore21;
            this.ParsingConfig.CustomTypeProvider = new DynamicLinkCustomTypeProvider();
            this.ParsingConfig.ResolveTypesBySimpleName = true;

            this.PredicateFactory = new PredicateFactory();
            this.CriterionFormatter = new EFCoreCriterionFormatter<T>();
        }
    }
}
