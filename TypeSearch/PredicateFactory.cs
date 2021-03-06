﻿using System;
using TypeSearch.Criteria;

namespace TypeSearch
{
    /// <summary>
    /// Factory responsible for producing predicates
    /// </summary>
    static class PredicateFactory
    {
        /// <summary>
        /// Create an operation specific predicate
        /// </summary>
        /// <param name="name">Parameterized property name</param>
        /// <param name="value">Parameterized value</param>
        /// <param name="operator">Operator</param>
        /// <returns></returns>
        public static string Create(string name, string value, SingleOperator @operator)
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
                    predicate = $"({name} == null ? string.Empty : {name}.ToString()).StartsWith({value})";
                    break;
                case SingleOperator.EndsWith:
                    predicate = $"({name} == null ? string.Empty : {name}.ToString()).EndsWith({value})";
                    break;
                case SingleOperator.Like:
                    predicate = $"({name} == null ? string.Empty : {name}.ToString()).Contains({value})";
                    break;
                case SingleOperator.DoesNotStartWith:
                    predicate = $"!({name} == null ? string.Empty : {name}.ToString()).StartsWith({value})";
                    break;
                case SingleOperator.DoesNotEndWith:
                    predicate = $"!({name} == null ? string.Empty : {name}.ToString()).EndsWith({value})";
                    break;
                case SingleOperator.NotLike:
                    predicate = $"!({name} == null ? string.Empty : {name}.ToString()).Contains({value})";
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

        /// <summary>
        /// Create an operation specific predicate
        /// </summary>
        /// <param name="name">Parameterized property name</param>
        /// <param name="startValue">Parameterized start value</param>
        /// <param name="endValue">Parameterized end value</param>
        /// <param name="operator">Operator</param>
        /// <returns></returns>
        public static string Create(string name, string startValue, string endValue, RangeOperator @operator)
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
