using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria
{
    /// <summary>
    /// Interface for formatting criteria
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICriterionFormatter<T>
        where T : class
    {
        /// <summary>
        /// Reset the parameter count
        /// </summary>
        public void ResetCount();

        /// <summary>
        /// Get the formatted value
        /// </summary>
        /// <param name="singleCriterion"></param>
        /// <returns></returns>
        public object GetFormattedValue(SingleCriterion<T> singleCriterion);

        /// <summary>
        /// Get the parameterized value
        /// </summary>
        /// <param name="singleCriterion"></param>
        /// <returns></returns>
        public (string Key, object Value) GetParameterizedValue(SingleCriterion<T> singleCriterion);

        /// <summary>
        /// Get the parameterized name
        /// </summary>
        /// <param name="singleCriterion"></param>
        /// <returns></returns>
        public string GetParameterizedName(SingleCriterion<T> singleCriterion);

        /// <summary>
        /// Get the parameterized name for a nested criterion
        /// </summary>
        /// <param name="singleCriterion"></param>
        /// <returns></returns>
        public string GetParameterizedCollectionName(SingleCriterion<T> singleCriterion);

        /// <summary>
        /// Get the formatted start value
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public object GetFormattedStartValue(RangeCriterion rangeCriterion);

        /// <summary>
        /// Get the formatted end value
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public object GetFormattedEndValue(RangeCriterion rangeCriterion);

        /// <summary>
        /// Get the parameterized start value
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public (string Key, object Value) GetParameterizedStartValue(RangeCriterion rangeCriterion);

        /// <summary>
        /// Get the parameterized end value
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public (string Key, object Value) GetParameterizedEndValue(RangeCriterion rangeCriterion);

        /// <summary>
        /// Get the parameterized name
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public string GetParameterizedName(RangeCriterion rangeCriterion);

        /// <summary>
        /// Get the parameterized name for a nested criterion
        /// </summary>
        /// <param name="rangeCriterion"></param>
        /// <returns></returns>
        public string GetParameterizedCollectionName(RangeCriterion rangeCriterion);

        /// <summary>
        /// Get the parameterized name
        /// </summary>
        /// <param name="sortCriterion"></param>
        /// <returns></returns>
        public string GetParameterizedName(SortCriterion sortCriterion);
    }
}
