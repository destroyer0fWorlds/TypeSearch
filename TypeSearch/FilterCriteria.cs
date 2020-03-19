using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TypeSearch.Criteria;
using TypeSearch.Operations;

namespace TypeSearch
{
    /// <summary>
    /// Filter (where) criteria
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FilterCriteria<T>
        where T : class
    {
        /// <summary>
        /// Filter criteria collection
        /// </summary>
        public List<CriteriaContainer<T>> Criteria { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterCriteria{T}"/> class
        /// </summary>
        public FilterCriteria()
        {
            this.Criteria = new List<CriteriaContainer<T>>();
        }

        #region Where

        /// <summary>
        /// Create a sub-query in the form "... AND (sub-query)"
        /// </summary>
        /// <param name="criteriaCollection">Sub-criteria</param>
        /// <returns></returns>
        public FilterCriteria<T> Where(FilterCriteria<T> criteriaCollection)
        {
            this.Criteria.Add(new CriteriaContainer<T>() { NestedFilter = criteriaCollection, Operator = LogicalOperator.And });
            return this;
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public BooleanOperation<T, bool> Where(Expression<Func<T, bool>> exp)
        {
            return new BooleanOperation<T, bool>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableBooleanOperation<T> Where(Expression<Func<T, bool?>> exp)
        {
            return new NullableBooleanOperation<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableStringOperation<T, string> Where(Expression<Func<T, string>> exp)
        {
            return new NullableStringOperation<T, string>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public ObjectOperation<T, Guid> Where(Expression<Func<T, Guid>> exp)
        {
            return new ObjectOperation<T, Guid>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableOperation<T, Guid?> Where(Expression<Func<T, Guid?>> exp)
        {
            return new NullableOperation<T, Guid?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, DateTime> Where(Expression<Func<T, DateTime>> exp)
        {
            return new NumberOperation<T, DateTime>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, DateTime?> Where(Expression<Func<T, DateTime?>> exp)
        {
            return new NullableNumberOperation<T, DateTime?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, sbyte> Where(Expression<Func<T, sbyte>> exp)
        {
            return new NumberOperation<T, sbyte>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, sbyte?> Where(Expression<Func<T, sbyte?>> exp)
        {
            return new NullableNumberOperation<T, sbyte?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, byte> Where(Expression<Func<T, byte>> exp)
        {
            return new NumberOperation<T, byte>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, byte?> Where(Expression<Func<T, byte?>> exp)
        {
            return new NullableNumberOperation<T, byte?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, short> Where(Expression<Func<T, short>> exp)
        {
            return new NumberOperation<T, short>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, short?> Where(Expression<Func<T, short?>> exp)
        {
            return new NullableNumberOperation<T, short?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, ushort> Where(Expression<Func<T, ushort>> exp)
        {
            return new NumberOperation<T, ushort>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, ushort?> Where(Expression<Func<T, ushort?>> exp)
        {
            return new NullableNumberOperation<T, ushort?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, int> Where(Expression<Func<T, int>> exp)
        {
            return new NumberOperation<T, int>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, int?> Where(Expression<Func<T, int?>> exp)
        {
            return new NullableNumberOperation<T, int?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, uint> Where(Expression<Func<T, uint>> exp)
        {
            return new NumberOperation<T, uint>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, uint?> Where(Expression<Func<T, uint?>> exp)
        {
            return new NullableNumberOperation<T, uint?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, long> Where(Expression<Func<T, long>> exp)
        {
            return new NumberOperation<T, long>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, long?> Where(Expression<Func<T, long?>> exp)
        {
            return new NullableNumberOperation<T, long?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, ulong> Where(Expression<Func<T, ulong>> exp)
        {
            return new NumberOperation<T, ulong>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, ulong?> Where(Expression<Func<T, ulong?>> exp)
        {
            return new NullableNumberOperation<T, ulong?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, float> Where(Expression<Func<T, float>> exp)
        {
            return new NumberOperation<T, float>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, float?> Where(Expression<Func<T, float?>> exp)
        {
            return new NullableNumberOperation<T, float?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, decimal> Where(Expression<Func<T, decimal>> exp)
        {
            return new NumberOperation<T, decimal>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, decimal?> Where(Expression<Func<T, decimal?>> exp)
        {
            return new NullableNumberOperation<T, decimal?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, double> Where(Expression<Func<T, double>> exp)
        {
            return new NumberOperation<T, double>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, double?> Where(Expression<Func<T, double?>> exp)
        {
            return new NullableNumberOperation<T, double?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp">Collection property name</param>
        /// <returns></returns>
        public EnumerableOperation<T, TResult> Where<TResult>(Expression<Func<T, IEnumerable<TResult>>> exp) where TResult : class
        {
            return new EnumerableOperation<T, TResult>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        #endregion

        #region And

        /// <summary>
        /// Create a sub-query in the form "... AND (sub-query)"
        /// </summary>
        /// <param name="criteriaCollection">Sub-criteria</param>
        /// <returns></returns>
        public FilterCriteria<T> And(FilterCriteria<T> criteriaCollection)
        {
            this.Criteria.Add(new CriteriaContainer<T>() { NestedFilter = criteriaCollection, Operator = LogicalOperator.And });
            return this;
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public BooleanOperation<T, bool> And(Expression<Func<T, bool>> exp)
        {
            return new BooleanOperation<T, bool>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableBooleanOperation<T> And(Expression<Func<T, bool?>> exp)
        {
            return new NullableBooleanOperation<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public StringOperation<T, string> And(Expression<Func<T, string>> exp)
        {
            return new StringOperation<T, string>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public ObjectOperation<T, Guid> And(Expression<Func<T, Guid>> exp)
        {
            return new ObjectOperation<T, Guid>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableOperation<T, Guid?> And(Expression<Func<T, Guid?>> exp)
        {
            return new NullableOperation<T, Guid?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, DateTime> And(Expression<Func<T, DateTime>> exp)
        {
            return new NumberOperation<T, DateTime>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, DateTime?> And(Expression<Func<T, DateTime?>> exp)
        {
            return new NullableNumberOperation<T, DateTime?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, sbyte> And(Expression<Func<T, sbyte>> exp)
        {
            return new NumberOperation<T, sbyte>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, sbyte?> And(Expression<Func<T, sbyte?>> exp)
        {
            return new NullableNumberOperation<T, sbyte?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, byte> And(Expression<Func<T, byte>> exp)
        {
            return new NumberOperation<T, byte>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, byte?> And(Expression<Func<T, byte?>> exp)
        {
            return new NullableNumberOperation<T, byte?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, short> And(Expression<Func<T, short>> exp)
        {
            return new NumberOperation<T, short>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, short?> And(Expression<Func<T, short?>> exp)
        {
            return new NullableNumberOperation<T, short?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, ushort> And(Expression<Func<T, ushort>> exp)
        {
            return new NumberOperation<T, ushort>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, ushort?> And(Expression<Func<T, ushort?>> exp)
        {
            return new NullableNumberOperation<T, ushort?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, int> And(Expression<Func<T, int>> exp)
        {
            return new NumberOperation<T, int>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, int?> And(Expression<Func<T, int?>> exp)
        {
            return new NullableNumberOperation<T, int?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, uint> And(Expression<Func<T, uint>> exp)
        {
            return new NumberOperation<T, uint>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, uint?> And(Expression<Func<T, uint?>> exp)
        {
            return new NullableNumberOperation<T, uint?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, long> And(Expression<Func<T, long>> exp)
        {
            return new NumberOperation<T, long>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, long?> And(Expression<Func<T, long?>> exp)
        {
            return new NullableNumberOperation<T, long?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, ulong> And(Expression<Func<T, ulong>> exp)
        {
            return new NumberOperation<T, ulong>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, ulong?> And(Expression<Func<T, ulong?>> exp)
        {
            return new NullableNumberOperation<T, ulong?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, float> And(Expression<Func<T, float>> exp)
        {
            return new NumberOperation<T, float>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, float?> And(Expression<Func<T, float?>> exp)
        {
            return new NullableNumberOperation<T, float?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, decimal> And(Expression<Func<T, decimal>> exp)
        {
            return new NumberOperation<T, decimal>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, decimal?> And(Expression<Func<T, decimal?>> exp)
        {
            return new NullableNumberOperation<T, decimal?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, double> And(Expression<Func<T, double>> exp)
        {
            return new NumberOperation<T, double>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, double?> And(Expression<Func<T, double?>> exp)
        {
            return new NullableNumberOperation<T, double?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp">Collection property name</param>
        /// <returns></returns>
        public EnumerableOperation<T, TResult> And<TResult>(Expression<Func<T, IEnumerable<TResult>>> exp) where TResult : class
        {
            return new EnumerableOperation<T, TResult>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        #endregion

        #region Or

        /// <summary>
        /// Create a sub-query in the form "... OR (sub-query)"
        /// </summary>
        /// <param name="criteriaCollection">Sub-criteria</param>
        /// <returns></returns>
        public FilterCriteria<T> Or(FilterCriteria<T> criteriaCollection)
        {
            this.Criteria.Add(new CriteriaContainer<T>() { NestedFilter = criteriaCollection, Operator = LogicalOperator.Or });
            return this;
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public BooleanOperation<T, bool> Or(Expression<Func<T, bool>> exp)
        {
            return new BooleanOperation<T, bool>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableBooleanOperation<T> Or(Expression<Func<T, bool?>> exp)
        {
            return new NullableBooleanOperation<T>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public StringOperation<T, string> Or(Expression<Func<T, string>> exp)
        {
            return new StringOperation<T, string>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public ObjectOperation<T, Guid> Or(Expression<Func<T, Guid>> exp)
        {
            return new ObjectOperation<T, Guid>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableOperation<T, Guid?> Or(Expression<Func<T, Guid?>> exp)
        {
            return new NullableOperation<T, Guid?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, DateTime> Or(Expression<Func<T, DateTime>> exp)
        {
            return new NumberOperation<T, DateTime>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, DateTime?> Or(Expression<Func<T, DateTime?>> exp)
        {
            return new NullableNumberOperation<T, DateTime?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, sbyte> Or(Expression<Func<T, sbyte>> exp)
        {
            return new NumberOperation<T, sbyte>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, sbyte?> Or(Expression<Func<T, sbyte?>> exp)
        {
            return new NullableNumberOperation<T, sbyte?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, byte> Or(Expression<Func<T, byte>> exp)
        {
            return new NumberOperation<T, byte>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, byte?> Or(Expression<Func<T, byte?>> exp)
        {
            return new NullableNumberOperation<T, byte?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, short> Or(Expression<Func<T, short>> exp)
        {
            return new NumberOperation<T, short>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, short?> Or(Expression<Func<T, short?>> exp)
        {
            return new NullableNumberOperation<T, short?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, ushort> Or(Expression<Func<T, ushort>> exp)
        {
            return new NumberOperation<T, ushort>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, ushort?> Or(Expression<Func<T, ushort?>> exp)
        {
            return new NullableNumberOperation<T, ushort?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, int> Or(Expression<Func<T, int>> exp)
        {
            return new NumberOperation<T, int>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, int?> Or(Expression<Func<T, int?>> exp)
        {
            return new NullableNumberOperation<T, int?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, uint> Or(Expression<Func<T, uint>> exp)
        {
            return new NumberOperation<T, uint>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, uint?> Or(Expression<Func<T, uint?>> exp)
        {
            return new NullableNumberOperation<T, uint?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, long> Or(Expression<Func<T, long>> exp)
        {
            return new NumberOperation<T, long>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, long?> Or(Expression<Func<T, long?>> exp)
        {
            return new NullableNumberOperation<T, long?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, ulong> Or(Expression<Func<T, ulong>> exp)
        {
            return new NumberOperation<T, ulong>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, ulong?> Or(Expression<Func<T, ulong?>> exp)
        {
            return new NullableNumberOperation<T, ulong?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, float> Or(Expression<Func<T, float>> exp)
        {
            return new NumberOperation<T, float>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, float?> Or(Expression<Func<T, float?>> exp)
        {
            return new NullableNumberOperation<T, float?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, decimal> Or(Expression<Func<T, decimal>> exp)
        {
            return new NumberOperation<T, decimal>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, decimal?> Or(Expression<Func<T, decimal?>> exp)
        {
            return new NullableNumberOperation<T, decimal?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, double> Or(Expression<Func<T, double>> exp)
        {
            return new NumberOperation<T, double>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, double?> Or(Expression<Func<T, double?>> exp)
        {
            return new NullableNumberOperation<T, double?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp">Collection property name</param>
        /// <returns></returns>
        public EnumerableOperation<T, TResult> Or<TResult>(Expression<Func<T, IEnumerable<TResult>>> exp) where TResult : class
        {
            return new EnumerableOperation<T, TResult>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        #endregion
    }
}
