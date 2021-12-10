using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using System.Runtime.CompilerServices;

namespace TypeSearch.Providers.EFCore
{
    // This is necessary to get the Dynamic Linq library to use the LIKE operator
    class DynamicLinkCustomTypeProvider : IDynamicLinkCustomTypeProvider
    {
        public HashSet<Type> GetCustomTypes()
        {
            HashSet<Type> types = new HashSet<Type>();
            types.Add(typeof(EF));
            //types.Add(typeof(DbFunctions));
            types.Add(typeof(DbFunctionsExtensions));
            //types.Add(typeof(DynamicFunctions));
            return types;
        }

        public Dictionary<Type, List<MethodInfo>> GetExtensionMethods()
        {
            var typeMethods = new Dictionary<Type, List<MethodInfo>>();

            var types = GetCustomTypes();
            foreach (var type in types)
            {
                var extensionMethods = type
                    .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(x => x.IsDefined(typeof(ExtensionAttribute), false))
                    .ToList();

                if (extensionMethods.Any())
                {
                    typeMethods.Add(type, extensionMethods);
                }
            }

            return typeMethods;
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
