using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TypeSearch.Criteria.Types
{
    /// <summary>
    /// Exposes collection specific operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumerableCriterion<T>
        where T : class
    {
        private readonly string _collectionName;
        private readonly LogicalOperator _operator;
        private readonly WhereCriteria<T> _whereCriteria;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableCriterion{T}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="whereCriteria">Parent filter criteria</param>
        public EnumerableCriterion(string collectionName, LogicalOperator @operator, WhereCriteria<T> whereCriteria)
        {
            _collectionName = collectionName;
            _operator = @operator;
            _whereCriteria = whereCriteria;
        }
        
        /// <summary>
        /// Collection property
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableCriterion<T, TResult> Property<TResult>(Expression<Func<T, TResult>> exp)
        {
            return new NullableCriterion<T, TResult>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public BoolCriterion<T> Property(Expression<Func<T, bool>> exp)
        {
            return new BoolCriterion<T>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableBoolCriterion<T> Property(Expression<Func<T, bool?>> exp)
        {
            return new NullableBoolCriterion<T>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public StringCriterion<T> Property(Expression<Func<T, string>> exp)
        {
            return new StringCriterion<T>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public ObjectCriterion<T, Guid> Property(Expression<Func<T, Guid>> exp)
        {
            return new ObjectCriterion<T, Guid>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableCriterion<T, Guid?> Property(Expression<Func<T, Guid?>> exp)
        {
            return new NullableCriterion<T, Guid?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, DateTime> Property(Expression<Func<T, DateTime>> exp)
        {
            return new NumberCriterion<T, DateTime>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, DateTime?> Property(Expression<Func<T, DateTime?>> exp)
        {
            return new NullableNumberCriterion<T, DateTime?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, sbyte> Property(Expression<Func<T, sbyte>> exp)
        {
            return new NumberCriterion<T, sbyte>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, sbyte?> Property(Expression<Func<T, sbyte?>> exp)
        {
            return new NullableNumberCriterion<T, sbyte?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, byte> Property(Expression<Func<T, byte>> exp)
        {
            return new NumberCriterion<T, byte>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, byte?> Property(Expression<Func<T, byte?>> exp)
        {
            return new NullableNumberCriterion<T, byte?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, short> Property(Expression<Func<T, short>> exp)
        {
            return new NumberCriterion<T, short>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, short?> Property(Expression<Func<T, short?>> exp)
        {
            return new NullableNumberCriterion<T, short?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, ushort> Property(Expression<Func<T, ushort>> exp)
        {
            return new NumberCriterion<T, ushort>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, ushort?> Property(Expression<Func<T, ushort?>> exp)
        {
            return new NullableNumberCriterion<T, ushort?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, int> Property(Expression<Func<T, int>> exp)
        {
            return new NumberCriterion<T, int>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, int?> Property(Expression<Func<T, int?>> exp)
        {
            return new NullableNumberCriterion<T, int?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, uint> Property(Expression<Func<T, uint>> exp)
        {
            return new NumberCriterion<T, uint>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, uint?> Property(Expression<Func<T, uint?>> exp)
        {
            return new NullableNumberCriterion<T, uint?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, long> Property(Expression<Func<T, long>> exp)
        {
            return new NumberCriterion<T, long>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, long?> Property(Expression<Func<T, long?>> exp)
        {
            return new NullableNumberCriterion<T, long?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, ulong> Property(Expression<Func<T, ulong>> exp)
        {
            return new NumberCriterion<T, ulong>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, ulong?> Property(Expression<Func<T, ulong?>> exp)
        {
            return new NullableNumberCriterion<T, ulong?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, float> Property(Expression<Func<T, float>> exp)
        {
            return new NumberCriterion<T, float>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, float?> Property(Expression<Func<T, float?>> exp)
        {
            return new NullableNumberCriterion<T, float?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, decimal> Property(Expression<Func<T, decimal>> exp)
        {
            return new NumberCriterion<T, decimal>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, decimal?> Property(Expression<Func<T, decimal?>> exp)
        {
            return new NullableNumberCriterion<T, decimal?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberCriterion<T, double> Property(Expression<Func<T, double>> exp)
        {
            return new NumberCriterion<T, double>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberCriterion<T, double?> Property(Expression<Func<T, double?>> exp)
        {
            return new NullableNumberCriterion<T, double?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }
    }
}
