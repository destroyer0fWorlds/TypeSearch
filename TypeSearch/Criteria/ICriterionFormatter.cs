using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria
{
    public interface ICriterionFormatter<T>
        where T : class
    {
        public void ResetCount();

        public object GetFormattedValue(SingleCriterion<T> singleCriterion);

        public (string Key, object Value) GetParameterizedValue(SingleCriterion<T> singleCriterion);

        public string GetParameterizedName(SingleCriterion<T> singleCriterion);

        public string GetParameterizedCollectionName(SingleCriterion<T> singleCriterion);

        public object GetFormattedStartValue(RangeCriterion rangeCriterion);

        public object GetFormattedEndValue(RangeCriterion rangeCriterion);

        public (string Key, object Value) GetParameterizedStartValue(RangeCriterion rangeCriterion);

        public (string Key, object Value) GetParameterizedEndValue(RangeCriterion rangeCriterion);

        public string GetParameterizedName(RangeCriterion rangeCriterion);

        public string GetParameterizedCollectionName(RangeCriterion rangeCriterion);

        public string GetParameterizedName(SortCriterion sortCriterion);
    }
}
