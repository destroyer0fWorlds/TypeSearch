using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria
{
    /// <summary>
    /// Default implementation of <see cref="ICriterionFormatter{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CriterionFormatter<T> : ICriterionFormatter<T>
        where T : class
    {
        private int _criteriaCount;

        /// <summary>
        /// Reset the parameter count
        /// </summary>
        public void ResetCount() => _criteriaCount = 0;

        /// <summary>
        /// Parameterize a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual string Parameterize(object value)
        {
            return $"@{value}";
        }

        /// <summary>
        /// Parameterize a name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual string ParameterizeName(string name)
        {
            return this.Parameterize(name);
        }

        /// <summary>
        /// Get the parameterized name for a nested criterion
        /// </summary>
        /// <param name="singleCriterion"></param>
        /// <returns></returns>
        public virtual string GetParameterizedCollectionName(SingleCriterion<T> singleCriterion)
        {
            return this.ParameterizeName(singleCriterion.CollectionName);
        }

        /// <summary>
        /// Get the parameterized name for a nested criterion
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public virtual string GetParameterizedCollectionName(RangeCriterion rangeCriterion)
        {
            return this.ParameterizeName(rangeCriterion.CollectionName);
        }

        /// <summary>
        /// Get the parameterized name
        /// </summary>
        /// <param name="singleCriterion"></param>
        /// <returns></returns>
        public virtual string GetParameterizedName(SingleCriterion<T> singleCriterion)
        {
            return this.ParameterizeName(singleCriterion.Name);
        }

        /// <summary>
        /// Get the parameterized name
        /// </summary>
        /// <param name="sortCriterion"></param>
        /// <returns></returns>
        public virtual string GetParameterizedName(SortCriterion sortCriterion)
        {
            return this.ParameterizeName(sortCriterion.Name);
        }

        /// <summary>
        /// Get the parameterized name
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public virtual string GetParameterizedName(RangeCriterion rangeCriterion)
        {
            return this.ParameterizeName(rangeCriterion.Name);
        }

        /// <summary>
        /// Get the parameterized start value
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public virtual (string Key, object Value) GetParameterizedStartValue(RangeCriterion rangeCriterion)
        {
            return (Key: this.Parameterize(_criteriaCount++), Value: this.GetFormattedStartValue(rangeCriterion));
        }

        /// <summary>
        /// Get the parameterized end value
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public virtual (string Key, object Value) GetParameterizedEndValue(RangeCriterion rangeCriterion)
        {
            return (Key: this.Parameterize(_criteriaCount++), Value: this.GetFormattedEndValue(rangeCriterion));
        }

        /// <summary>
        /// Get the parameterized value
        /// </summary>
        /// <param name="singleCriterion"></param>
        /// <returns></returns>
        public virtual (string Key, object Value) GetParameterizedValue(SingleCriterion<T> singleCriterion)
        {
            return (Key: this.Parameterize(_criteriaCount++), Value: this.GetFormattedValue(singleCriterion));
        }

        /// <summary>
        /// Get the formatted value
        /// </summary>
        /// <param name="singleCriterion"></param>
        /// <returns></returns>
        public abstract object GetFormattedValue(SingleCriterion<T> singleCriterion);

        /// <summary>
        /// Get the formatted start value
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public abstract object GetFormattedStartValue(RangeCriterion rangeCriterion);

        /// <summary>
        /// Get the formatted end value
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public abstract object GetFormattedEndValue(RangeCriterion rangeCriterion);
    }
}
