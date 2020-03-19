using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TypeSearch.Operations.Enumerable
{
    /// <summary>
    /// Exposes the operations available to collections
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumerableOperation<T>
        where T : class
    {
        private readonly string _collectionName;
        private readonly LogicalOperator _operator;
        private readonly FilterCriteria<T> _whereCriteria;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableOperation{T}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="whereCriteria">Parent filter criteria</param>
        public EnumerableOperation(string collectionName, LogicalOperator @operator, FilterCriteria<T> whereCriteria)
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
        public NullableOperation<T, TResult> Property<TResult>(Expression<Func<T, TResult>> exp)
        {
            return new NullableOperation<T, TResult>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public BooleanOperation<T, bool> Property(Expression<Func<T, bool>> exp)
        {
            return new BooleanOperation<T, bool>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableBooleanOperation<T> Property(Expression<Func<T, bool?>> exp)
        {
            return new NullableBooleanOperation<T>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableStringOperation<T, string> Property(Expression<Func<T, string>> exp)
        {
            return new NullableStringOperation<T, string>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public ObjectOperation<T, Guid> Property(Expression<Func<T, Guid>> exp)
        {
            return new ObjectOperation<T, Guid>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableOperation<T, Guid?> Property(Expression<Func<T, Guid?>> exp)
        {
            return new NullableOperation<T, Guid?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, DateTime> Property(Expression<Func<T, DateTime>> exp)
        {
            return new NumberOperation<T, DateTime>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, DateTime?> Property(Expression<Func<T, DateTime?>> exp)
        {
            return new NullableNumberOperation<T, DateTime?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, sbyte> Property(Expression<Func<T, sbyte>> exp)
        {
            return new NumberOperation<T, sbyte>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, sbyte?> Property(Expression<Func<T, sbyte?>> exp)
        {
            return new NullableNumberOperation<T, sbyte?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, byte> Property(Expression<Func<T, byte>> exp)
        {
            return new NumberOperation<T, byte>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, byte?> Property(Expression<Func<T, byte?>> exp)
        {
            return new NullableNumberOperation<T, byte?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, short> Property(Expression<Func<T, short>> exp)
        {
            return new NumberOperation<T, short>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, short?> Property(Expression<Func<T, short?>> exp)
        {
            return new NullableNumberOperation<T, short?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, ushort> Property(Expression<Func<T, ushort>> exp)
        {
            return new NumberOperation<T, ushort>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, ushort?> Property(Expression<Func<T, ushort?>> exp)
        {
            return new NullableNumberOperation<T, ushort?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, int> Property(Expression<Func<T, int>> exp)
        {
            return new NumberOperation<T, int>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, int?> Property(Expression<Func<T, int?>> exp)
        {
            return new NullableNumberOperation<T, int?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, uint> Property(Expression<Func<T, uint>> exp)
        {
            return new NumberOperation<T, uint>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, uint?> Property(Expression<Func<T, uint?>> exp)
        {
            return new NullableNumberOperation<T, uint?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, long> Property(Expression<Func<T, long>> exp)
        {
            return new NumberOperation<T, long>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, long?> Property(Expression<Func<T, long?>> exp)
        {
            return new NullableNumberOperation<T, long?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, ulong> Property(Expression<Func<T, ulong>> exp)
        {
            return new NumberOperation<T, ulong>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, ulong?> Property(Expression<Func<T, ulong?>> exp)
        {
            return new NullableNumberOperation<T, ulong?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, float> Property(Expression<Func<T, float>> exp)
        {
            return new NumberOperation<T, float>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, float?> Property(Expression<Func<T, float?>> exp)
        {
            return new NullableNumberOperation<T, float?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, decimal> Property(Expression<Func<T, decimal>> exp)
        {
            return new NumberOperation<T, decimal>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, decimal?> Property(Expression<Func<T, decimal?>> exp)
        {
            return new NullableNumberOperation<T, decimal?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<T, double> Property(Expression<Func<T, double>> exp)
        {
            return new NumberOperation<T, double>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<T, double?> Property(Expression<Func<T, double?>> exp)
        {
            return new NullableNumberOperation<T, double?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _whereCriteria);
        }
    }
}
