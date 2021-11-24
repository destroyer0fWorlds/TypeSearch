using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Reflection;

namespace TypeSearch.EFCore
{
    public class EFCoreSearcher<T> : Searcher<T>
        where T : class
    {
        public EFCoreSearcher(IQueryable<T> dataSet) : base(dataSet, new PredicateFactory())
        {
            _config = ParsingConfig.DefaultEFCore21;
            _config.CustomTypeProvider = new DynamicLinqProvider();
            _config.ResolveTypesBySimpleName = true;
        }
    }

    class DynamicLinqProvider : IDynamicLinkCustomTypeProvider
    {
        public HashSet<Type> GetCustomTypes()
        {
            HashSet<Type> types = new HashSet<Type>();
            types.Add(typeof(DbFunctionsExtensions));
            types.Add(typeof(EF));
            return types;
        }

        public Dictionary<Type, List<MethodInfo>> GetExtensionMethods()
        {
            throw new NotImplementedException();
        }

        public Type ResolveType(string typeName)
        {
            throw new NotImplementedException();
        }

        public Type ResolveTypeBySimpleName(string simpleTypeName)
        {
            throw new NotImplementedException();
        }
    }
}
