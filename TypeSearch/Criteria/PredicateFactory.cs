using System;
using System.Collections.Generic;
using System.Text;
using TypeSearch.Criteria.Types;

namespace TypeSearch.Criteria
{
    static class PredicateFactory
    {
        public static IPredicate Create<T>(string propertyName, string parameterizedName, string parameterizedValue, SingleOperator @operator)
            where T : class
        {
            // Perform the least expensive check first
            switch (@operator)
            {
                case SingleOperator.Equals:
                case SingleOperator.NotEquals:
                case SingleOperator.GreaterThan:
                case SingleOperator.GreaterThanOrEqualTo:
                case SingleOperator.LessThan:
                case SingleOperator.LessThanOrEqualTo:
                case SingleOperator.IsNull:
                case SingleOperator.IsNotNull:
                    return new CommonPredicate(parameterizedName, parameterizedValue, @operator);
            }

            // Perform type check
            var type = typeof(T);
            var propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Invalid name '{propertyName}'. No property or column exists with the given name.", nameof(SingleCriterion<T>.Name));
            }

            var propertyType = propertyInfo.PropertyType;
            if (propertyType == typeof(string))
            {
                return new StringPredicate(parameterizedName, parameterizedValue, @operator);
            }
            else if (Nullable.GetUnderlyingType(propertyType) != null)
            {
                return new NullablePredicate(parameterizedName, parameterizedValue, @operator);
            }
            else
            {
                return new RealPredicate(parameterizedName, parameterizedValue, @operator);
            }
        }
    }
}
