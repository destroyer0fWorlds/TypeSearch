using System;
using System.Collections.Generic;
using System.Text;
using TypeSearch.Criteria;

namespace TypeSearch.EFCore
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
                    predicate = $"DynamicFunctions.Like({name}, \"{value}%\")";
                    break;
                case SingleOperator.EndsWith:
                    predicate = $"DynamicFunctions.Like({name}, \"%{value}\")";
                    break;
                case SingleOperator.Like:
                    predicate = $"DbFunctionsExtensions.Like(EF.Functions, {name}, {value})";
                    break;
                case SingleOperator.DoesNotStartWith:
                    predicate = $"!DynamicFunctions.Like({name}, \"{value}%\")";
                    break;
                case SingleOperator.DoesNotEndWith:
                    predicate = $"!DynamicFunctions.Like({name}, \"%{value}\")";
                    break;
                case SingleOperator.NotLike:
                    predicate = $"!DynamicFunctions.Like({name}, \"%{value}%\")";
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
