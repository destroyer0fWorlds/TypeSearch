using System;
using TypeSearch.Criteria;

namespace TypeSearch.Predicates
{
    static class PredicateFactory
    {
        public static IPredicate Create(string parameterizedName, string parameterizedValue, SingleOperator @operator)
        {
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
                    return new ComparisonPredicate(parameterizedName, parameterizedValue, @operator);
                case SingleOperator.StartsWith:
                case SingleOperator.EndsWith:
                case SingleOperator.Like:
                case SingleOperator.DoesNotStartWith:
                case SingleOperator.DoesNotEndWith:
                case SingleOperator.NotLike:
                    return new StringPredicate(parameterizedName, parameterizedValue, @operator);
                default:
                    throw new ArgumentException($"'{@operator}' is not a valid operation.");
            }
        }
    }
}
