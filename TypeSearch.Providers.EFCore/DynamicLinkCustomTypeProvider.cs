using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TypeSearch.Providers.EFCore
{
    // This is necessary to get the Dynamic Linq library to use the LIKE operator
    class DynamicLinkCustomTypeProvider : IDynamicLinkCustomTypeProvider
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
