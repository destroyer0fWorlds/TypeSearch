using System;
using System.Collections.Generic;
using System.Text;
using TypeSearch.Criteria;

namespace TypeSearch.Providers.EFCore
{
    class EFCoreCriterionFormatter<T> : CriterionFormatter<T>
        where T : class
    {
        public override object GetFormattedEndValue(RangeCriterion rangeCriterion)
        {
            return rangeCriterion.EndValue;
        }

        public override object GetFormattedStartValue(RangeCriterion rangeCriterion)
        {
            return rangeCriterion.StartValue;
        }

        public override object GetFormattedValue(SingleCriterion<T> singleCriterion)
        {
            var value = singleCriterion.Value;
            switch(singleCriterion.Operator)
            {
                case SingleOperator.StartsWith:
                case SingleOperator.DoesNotStartWith:
                    value = $"{value}%";
                    break;
                case SingleOperator.EndsWith:
                case SingleOperator.DoesNotEndWith:
                    value = $"%{value}";
                    break;
                case SingleOperator.Like:
                case SingleOperator.NotLike:
                    value = $"%{value}%";
                    break;
            }
            return value;
        }
    }
}
