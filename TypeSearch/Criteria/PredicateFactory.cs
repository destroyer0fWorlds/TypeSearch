using System;
using System.Collections.Generic;
using System.Text;
using TypeSearch.Criteria.Types;

namespace TypeSearch.Criteria
{
    static class PredicateFactory
    {
        public static IPredicate Create<T>(string propertyName, string value, SingleOperator @operator)
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
                    return new CommonPredicate(propertyName, value, @operator);
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
                return new StringPredicate(propertyName, value, @operator);
            }
            else if (Nullable.GetUnderlyingType(propertyType) != null)
            {
                return new NullablePredicate(propertyName, value, @operator);
            }
            else
            {
                return new RealPredicate(propertyName, value, @operator);
            }
        }
    }
}
