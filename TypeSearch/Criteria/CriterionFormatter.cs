using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria
{
    public abstract class CriterionFormatter<T> : ICriterionFormatter<T>
        where T : class
    {
        private int _criteriaCount;

        public void ResetCount() => _criteriaCount = 0;

        protected virtual string Parameterize(object value)
        {
            return $"@{value}";
        }

        protected virtual string ParameterizeName(string name)
        {
            return this.Parameterize(name);
        }

        public virtual string GetParameterizedCollectionName(SingleCriterion<T> singleCriterion)
        {
            return this.ParameterizeName(singleCriterion.CollectionName);
        }

        public virtual string GetParameterizedCollectionName(RangeCriterion rangeCriterion)
        {
            return this.ParameterizeName(rangeCriterion.CollectionName);
        }

        public virtual string GetParameterizedName(SingleCriterion<T> singleCriterion)
        {
            return this.ParameterizeName(singleCriterion.Name);
        }

        public virtual string GetParameterizedName(SortCriterion sortCriterion)
        {
            return this.ParameterizeName(sortCriterion.Name);
        }

        public virtual string GetParameterizedName(RangeCriterion rangeCriterion)
        {
            return this.ParameterizeName(rangeCriterion.Name);
        }

        public virtual (string Key, object Value) GetParameterizedStartValue(RangeCriterion rangeCriterion)
        {
            return (Key: this.Parameterize(_criteriaCount++), Value: this.GetFormattedStartValue(rangeCriterion));
        }

        public virtual (string Key, object Value) GetParameterizedEndValue(RangeCriterion rangeCriterion)
        {
            return (Key: this.Parameterize(_criteriaCount++), Value: this.GetFormattedEndValue(rangeCriterion));
        }

        public virtual (string Key, object Value) GetParameterizedValue(SingleCriterion<T> singleCriterion)
        {
            return (Key: this.Parameterize(_criteriaCount++), Value: this.GetFormattedValue(singleCriterion));
        }

        public abstract object GetFormattedValue(SingleCriterion<T> singleCriterion);

        public abstract object GetFormattedStartValue(RangeCriterion rangeCriterion);

        public abstract object GetFormattedEndValue(RangeCriterion rangeCriterion);
    }
}
