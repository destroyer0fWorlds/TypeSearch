using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TypeSearch.Criteria;
using TypeSearch.Criteria.Types;

namespace TypeSearch
{
    /// <summary>
    /// Filter (where) criteria
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WhereCriteria<T>
        where T : class
    {
        /// <summary>
        /// Filter criteria collection
        /// </summary>
        public List<CriteriaContainer<T>> Criteria { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereCriteria{T}"/> class
        /// </summary>
        public WhereCriteria()
        {
            this.Criteria = new List<CriteriaContainer<T>>();
        }

        #region Where

        /// <summary>
        /// Create a sub-query in the form "... AND (sub-query)"
        /// </summary>
        /// <param name="criteriaCollection">Sub-criteria</param>
        /// <returns></returns>
        public WhereCriteria<T> Where(WhereCriteria<T> criteriaCollection)
        {
            this.Criteria.Add(new CriteriaContainer<T>() { NestedFilter = criteriaCollection, Operator = LogicalOperator.And });
            return this;
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public BoolCriterion<T> Where(Expression<Func<T, bool>> exp)
        {
            return new BoolCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableBoolCriterion<T> Where(Expression<Func<T, bool?>> exp)
        {
            return new NullableBoolCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public StringCriterion<T> Where(Expression<Func<T, string>> exp)
        {
            return new StringCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public ObjectCriterion<T, Guid> Where(Expression<Func<T, Guid>> exp)
        {
            return new ObjectCriterion<T, Guid>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableCriterion<T, Guid?> Where(Expression<Func<T, Guid?>> exp)
        {
            return new NullableCriterion<T, Guid?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, DateTime> Where(Expression<Func<T, DateTime>> exp)
        {
            return new NumberCriterion<T, DateTime>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, DateTime?> Where(Expression<Func<T, DateTime?>> exp)
        {
            return new NullableNumberCriterion<T, DateTime?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, sbyte> Where(Expression<Func<T, sbyte>> exp)
        {
            return new NumberCriterion<T, sbyte>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, sbyte?> Where(Expression<Func<T, sbyte?>> exp)
        {
            return new NullableNumberCriterion<T, sbyte?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, byte> Where(Expression<Func<T, byte>> exp)
        {
            return new NumberCriterion<T, byte>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, byte?> Where(Expression<Func<T, byte?>> exp)
        {
            return new NullableNumberCriterion<T, byte?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, short> Where(Expression<Func<T, short>> exp)
        {
            return new NumberCriterion<T, short>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, short?> Where(Expression<Func<T, short?>> exp)
        {
            return new NullableNumberCriterion<T, short?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, ushort> Where(Expression<Func<T, ushort>> exp)
        {
            return new NumberCriterion<T, ushort>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, ushort?> Where(Expression<Func<T, ushort?>> exp)
        {
            return new NullableNumberCriterion<T, ushort?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, int> Where(Expression<Func<T, int>> exp)
        {
            return new NumberCriterion<T, int>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, int?> Where(Expression<Func<T, int?>> exp)
        {
            return new NullableNumberCriterion<T, int?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, uint> Where(Expression<Func<T, uint>> exp)
        {
            return new NumberCriterion<T, uint>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, uint?> Where(Expression<Func<T, uint?>> exp)
        {
            return new NullableNumberCriterion<T, uint?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, long> Where(Expression<Func<T, long>> exp)
        {
            return new NumberCriterion<T, long>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, long?> Where(Expression<Func<T, long?>> exp)
        {
            return new NullableNumberCriterion<T, long?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, ulong> Where(Expression<Func<T, ulong>> exp)
        {
            return new NumberCriterion<T, ulong>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, ulong?> Where(Expression<Func<T, ulong?>> exp)
        {
            return new NullableNumberCriterion<T, ulong?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, float> Where(Expression<Func<T, float>> exp)
        {
            return new NumberCriterion<T, float>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, float?> Where(Expression<Func<T, float?>> exp)
        {
            return new NullableNumberCriterion<T, float?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, decimal> Where(Expression<Func<T, decimal>> exp)
        {
            return new NumberCriterion<T, decimal>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, decimal?> Where(Expression<Func<T, decimal?>> exp)
        {
            return new NullableNumberCriterion<T, decimal?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, double> Where(Expression<Func<T, double>> exp)
        {
            return new NumberCriterion<T, double>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, double?> Where(Expression<Func<T, double?>> exp)
        {
            return new NullableNumberCriterion<T, double?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// Where statement. Multiple where statements result in multiple ANDs
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp">Collection property name</param>
        /// <returns></returns>
        public EnumerableCriterion<T> Where<TResult>(Expression<Func<T, IEnumerable<TResult>>> exp)
        {
            return new EnumerableCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        #endregion

        #region And

        /// <summary>
        /// Create a sub-query in the form "... AND (sub-query)"
        /// </summary>
        /// <param name="criteriaCollection">Sub-criteria</param>
        /// <returns></returns>
        public WhereCriteria<T> And(WhereCriteria<T> criteriaCollection)
        {
            this.Criteria.Add(new CriteriaContainer<T>() { NestedFilter = criteriaCollection, Operator = LogicalOperator.And });
            return this;
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public BoolCriterion<T> And(Expression<Func<T, bool>> exp)
        {
            return new BoolCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableBoolCriterion<T> And(Expression<Func<T, bool?>> exp)
        {
            return new NullableBoolCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public StringCriterion<T> And(Expression<Func<T, string>> exp)
        {
            return new StringCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public ObjectCriterion<T, Guid> And(Expression<Func<T, Guid>> exp)
        {
            return new ObjectCriterion<T, Guid>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableCriterion<T, Guid?> And(Expression<Func<T, Guid?>> exp)
        {
            return new NullableCriterion<T, Guid?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, DateTime> And(Expression<Func<T, DateTime>> exp)
        {
            return new NumberCriterion<T, DateTime>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, DateTime?> And(Expression<Func<T, DateTime?>> exp)
        {
            return new NullableNumberCriterion<T, DateTime?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, sbyte> And(Expression<Func<T, sbyte>> exp)
        {
            return new NumberCriterion<T, sbyte>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, sbyte?> And(Expression<Func<T, sbyte?>> exp)
        {
            return new NullableNumberCriterion<T, sbyte?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, byte> And(Expression<Func<T, byte>> exp)
        {
            return new NumberCriterion<T, byte>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, byte?> And(Expression<Func<T, byte?>> exp)
        {
            return new NullableNumberCriterion<T, byte?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, short> And(Expression<Func<T, short>> exp)
        {
            return new NumberCriterion<T, short>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, short?> And(Expression<Func<T, short?>> exp)
        {
            return new NullableNumberCriterion<T, short?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, ushort> And(Expression<Func<T, ushort>> exp)
        {
            return new NumberCriterion<T, ushort>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, ushort?> And(Expression<Func<T, ushort?>> exp)
        {
            return new NullableNumberCriterion<T, ushort?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, int> And(Expression<Func<T, int>> exp)
        {
            return new NumberCriterion<T, int>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, int?> And(Expression<Func<T, int?>> exp)
        {
            return new NullableNumberCriterion<T, int?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, uint> And(Expression<Func<T, uint>> exp)
        {
            return new NumberCriterion<T, uint>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, uint?> And(Expression<Func<T, uint?>> exp)
        {
            return new NullableNumberCriterion<T, uint?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, long> And(Expression<Func<T, long>> exp)
        {
            return new NumberCriterion<T, long>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, long?> And(Expression<Func<T, long?>> exp)
        {
            return new NullableNumberCriterion<T, long?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, ulong> And(Expression<Func<T, ulong>> exp)
        {
            return new NumberCriterion<T, ulong>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, ulong?> And(Expression<Func<T, ulong?>> exp)
        {
            return new NullableNumberCriterion<T, ulong?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, float> And(Expression<Func<T, float>> exp)
        {
            return new NumberCriterion<T, float>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, float?> And(Expression<Func<T, float?>> exp)
        {
            return new NullableNumberCriterion<T, float?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, decimal> And(Expression<Func<T, decimal>> exp)
        {
            return new NumberCriterion<T, decimal>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, decimal?> And(Expression<Func<T, decimal?>> exp)
        {
            return new NullableNumberCriterion<T, decimal?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, double> And(Expression<Func<T, double>> exp)
        {
            return new NumberCriterion<T, double>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, double?> And(Expression<Func<T, double?>> exp)
        {
            return new NullableNumberCriterion<T, double?>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        /// <summary>
        /// And statement
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp">Collection property name</param>
        /// <returns></returns>
        public EnumerableCriterion<T> And<TResult>(Expression<Func<T, IEnumerable<TResult>>> exp)
        {
            return new EnumerableCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.And, this);
        }

        #endregion

        #region Or

        /// <summary>
        /// Create a sub-query in the form "... OR (sub-query)"
        /// </summary>
        /// <param name="criteriaCollection">Sub-criteria</param>
        /// <returns></returns>
        public WhereCriteria<T> Or(WhereCriteria<T> criteriaCollection)
        {
            this.Criteria.Add(new CriteriaContainer<T>() { NestedFilter = criteriaCollection, Operator = LogicalOperator.Or });
            return this;
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public BoolCriterion<T> Or(Expression<Func<T, bool>> exp)
        {
            return new BoolCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableBoolCriterion<T> Or(Expression<Func<T, bool?>> exp)
        {
            return new NullableBoolCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public StringCriterion<T> Or(Expression<Func<T, string>> exp)
        {
            return new StringCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public ObjectCriterion<T, Guid> Or(Expression<Func<T, Guid>> exp)
        {
            return new ObjectCriterion<T, Guid>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableCriterion<T, Guid?> Or(Expression<Func<T, Guid?>> exp)
        {
            return new NullableCriterion<T, Guid?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, DateTime> Or(Expression<Func<T, DateTime>> exp)
        {
            return new NumberCriterion<T, DateTime>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, DateTime?> Or(Expression<Func<T, DateTime?>> exp)
        {
            return new NullableNumberCriterion<T, DateTime?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, sbyte> Or(Expression<Func<T, sbyte>> exp)
        {
            return new NumberCriterion<T, sbyte>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, sbyte?> Or(Expression<Func<T, sbyte?>> exp)
        {
            return new NullableNumberCriterion<T, sbyte?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, byte> Or(Expression<Func<T, byte>> exp)
        {
            return new NumberCriterion<T, byte>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, byte?> Or(Expression<Func<T, byte?>> exp)
        {
            return new NullableNumberCriterion<T, byte?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, short> Or(Expression<Func<T, short>> exp)
        {
            return new NumberCriterion<T, short>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, short?> Or(Expression<Func<T, short?>> exp)
        {
            return new NullableNumberCriterion<T, short?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, ushort> Or(Expression<Func<T, ushort>> exp)
        {
            return new NumberCriterion<T, ushort>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, ushort?> Or(Expression<Func<T, ushort?>> exp)
        {
            return new NullableNumberCriterion<T, ushort?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, int> Or(Expression<Func<T, int>> exp)
        {
            return new NumberCriterion<T, int>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, int?> Or(Expression<Func<T, int?>> exp)
        {
            return new NullableNumberCriterion<T, int?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, uint> Or(Expression<Func<T, uint>> exp)
        {
            return new NumberCriterion<T, uint>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, uint?> Or(Expression<Func<T, uint?>> exp)
        {
            return new NullableNumberCriterion<T, uint?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, long> Or(Expression<Func<T, long>> exp)
        {
            return new NumberCriterion<T, long>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, long?> Or(Expression<Func<T, long?>> exp)
        {
            return new NullableNumberCriterion<T, long?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, ulong> Or(Expression<Func<T, ulong>> exp)
        {
            return new NumberCriterion<T, ulong>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, ulong?> Or(Expression<Func<T, ulong?>> exp)
        {
            return new NullableNumberCriterion<T, ulong?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, float> Or(Expression<Func<T, float>> exp)
        {
            return new NumberCriterion<T, float>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, float?> Or(Expression<Func<T, float?>> exp)
        {
            return new NullableNumberCriterion<T, float?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, decimal> Or(Expression<Func<T, decimal>> exp)
        {
            return new NumberCriterion<T, decimal>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, decimal?> Or(Expression<Func<T, decimal?>> exp)
        {
            return new NullableNumberCriterion<T, decimal?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, double> Or(Expression<Func<T, double>> exp)
        {
            return new NumberCriterion<T, double>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, double?> Or(Expression<Func<T, double?>> exp)
        {
            return new NullableNumberCriterion<T, double?>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        /// <summary>
        /// Or statement
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp">Collection property name</param>
        /// <returns></returns>
        public EnumerableCriterion<T> Or<TResult>(Expression<Func<T, IEnumerable<TResult>>> exp)
        {
            return new EnumerableCriterion<T>(ExpressionHelper.GetName(exp), LogicalOperator.Or, this);
        }

        #endregion
    }
}
