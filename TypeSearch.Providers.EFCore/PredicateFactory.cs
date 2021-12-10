using System;
using TypeSearch.Criteria;

namespace TypeSearch.Providers.EFCore
{
    class PredicateFactory : IPredicateFactory
    {
        public string Create(string name, string value, SingleOperator @operator)
        {
            string predicate;
            switch (@operator)
            {
                case SingleOperator.Equals:
                    predicate = $"{name} == {value}";
                    break;
                case SingleOperator.NotEquals:
                    predicate = $"{name} != {value}";
                    break;
                case SingleOperator.GreaterThan:
                    predicate = $"{name} > {value}";
                    break;
                case SingleOperator.GreaterThanOrEqualTo:
                    predicate = $"{name} >= {value}";
                    break;
                case SingleOperator.LessThan:
                    predicate = $"{name} < {value}";
                    break;
                case SingleOperator.LessThanOrEqualTo:
                    predicate = $"{name} <= {value}";
                    break;
                case SingleOperator.IsNull:
                    predicate = $"{name} == {value}";
                    break;
                case SingleOperator.IsNotNull:
                    predicate = $"{name} != {value}";
                    break;
                case SingleOperator.StartsWith:
                case SingleOperator.EndsWith:
                case SingleOperator.Like:
                    predicate = $"DbFunctionsExtensions.Like(EF.Functions, {name}, {value})"; // this never hits the GetExtensionMethods method
                    //predicate = $"EF.Functions.Like({name}, {value})";
                    //predicate = $"DynamicFunctions.Like({name}, {value})";
                    break;
                case SingleOperator.DoesNotStartWith:                    
                case SingleOperator.DoesNotEndWith:
                case SingleOperator.NotLike:
                    predicate = $"!DbFunctionsExtensions.Like(EF.Functions, {name}, {value})";
                    break;
                case SingleOperator.In:
                    predicate = $"{value}.Contains({name})";
                    break;
                case SingleOperator.NotIn:
                    predicate = $"!{value}.Contains({name})";
                    break;
                default:
                    throw new ArgumentException($"'{@operator}' is not a valid operation.");
            }
            return predicate;
        }

        public string Create(string name, string startValue, string endValue, RangeOperator @operator)
        {
            string predicate;
            switch (@operator)
            {
                case RangeOperator.Between:
                    predicate = $"{name} >= {startValue} And {name} <= {endValue}";
                    break;
                case RangeOperator.NotBetween:
                    predicate = $"{name} < {startValue} Or {name} > {endValue}";
                    break;
                default:
                    throw new ArgumentException($"'{@operator}' is not a valid operation.");
            }
            return predicate;
        }
    }
}
