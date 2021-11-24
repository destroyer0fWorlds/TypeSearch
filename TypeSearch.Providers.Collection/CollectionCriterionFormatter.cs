using System;
using System.Collections.Generic;
using System.Text;
using TypeSearch.Criteria;

namespace TypeSearch.Providers.Collection
{
    class CollectionCriterionFormatter<T> : CriterionFormatter<T>
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
            return singleCriterion.Value;
        }
    }
}
