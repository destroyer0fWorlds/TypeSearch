using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to collections
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class EnumerableOperation<TParent, T>
        where TParent : class
        where T : class
    {
        private readonly string _collectionName;
        private readonly LogicalOperator _operator;
        private readonly FilterCriteria<TParent> _filter;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableOperation{TParent, T}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public EnumerableOperation(string collectionName, LogicalOperator @operator, FilterCriteria<TParent> filter)
        {
            _collectionName = collectionName;
            _operator = @operator;
            _filter = filter;
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableOperation<TParent, TResult> Property<TResult>(Expression<Func<T, TResult>> exp)
        {
            return new NullableOperation<TParent, TResult>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public BooleanOperation<TParent, bool> Property(Expression<Func<T, bool>> exp)
        {
            return new BooleanOperation<TParent, bool>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableBooleanOperation<TParent> Property(Expression<Func<T, bool?>> exp)
        {
            return new NullableBooleanOperation<TParent>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableStringOperation<TParent, string> Property(Expression<Func<T, string>> exp)
        {
            return new NullableStringOperation<TParent, string>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public ObjectOperation<TParent, Guid> Property(Expression<Func<T, Guid>> exp)
        {
            return new ObjectOperation<TParent, Guid>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableOperation<TParent, Guid?> Property(Expression<Func<T, Guid?>> exp)
        {
            return new NullableOperation<TParent, Guid?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, DateTime> Property(Expression<Func<T, DateTime>> exp)
        {
            return new NumberOperation<TParent, DateTime>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, DateTime?> Property(Expression<Func<T, DateTime?>> exp)
        {
            return new NullableNumberOperation<TParent, DateTime?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, sbyte> Property(Expression<Func<T, sbyte>> exp)
        {
            return new NumberOperation<TParent, sbyte>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, sbyte?> Property(Expression<Func<T, sbyte?>> exp)
        {
            return new NullableNumberOperation<TParent, sbyte?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, byte> Property(Expression<Func<T, byte>> exp)
        {
            return new NumberOperation<TParent, byte>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, byte?> Property(Expression<Func<T, byte?>> exp)
        {
            return new NullableNumberOperation<TParent, byte?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, short> Property(Expression<Func<T, short>> exp)
        {
            return new NumberOperation<TParent, short>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, short?> Property(Expression<Func<T, short?>> exp)
        {
            return new NullableNumberOperation<TParent, short?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, ushort> Property(Expression<Func<T, ushort>> exp)
        {
            return new NumberOperation<TParent, ushort>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, ushort?> Property(Expression<Func<T, ushort?>> exp)
        {
            return new NullableNumberOperation<TParent, ushort?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, int> Property(Expression<Func<T, int>> exp)
        {
            return new NumberOperation<TParent, int>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, int?> Property(Expression<Func<T, int?>> exp)
        {
            return new NullableNumberOperation<TParent, int?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, uint> Property(Expression<Func<T, uint>> exp)
        {
            return new NumberOperation<TParent, uint>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, uint?> Property(Expression<Func<T, uint?>> exp)
        {
            return new NullableNumberOperation<TParent, uint?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, long> Property(Expression<Func<T, long>> exp)
        {
            return new NumberOperation<TParent, long>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, long?> Property(Expression<Func<T, long?>> exp)
        {
            return new NullableNumberOperation<TParent, long?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, ulong> Property(Expression<Func<T, ulong>> exp)
        {
            return new NumberOperation<TParent, ulong>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, ulong?> Property(Expression<Func<T, ulong?>> exp)
        {
            return new NullableNumberOperation<TParent, ulong?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, float> Property(Expression<Func<T, float>> exp)
        {
            return new NumberOperation<TParent, float>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, float?> Property(Expression<Func<T, float?>> exp)
        {
            return new NullableNumberOperation<TParent, float?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, decimal> Property(Expression<Func<T, decimal>> exp)
        {
            return new NumberOperation<TParent, decimal>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, decimal?> Property(Expression<Func<T, decimal?>> exp)
        {
            return new NullableNumberOperation<TParent, decimal?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NumberOperation<TParent, double> Property(Expression<Func<T, double>> exp)
        {
            return new NumberOperation<TParent, double>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }

        /// <summary>
        /// Collection property
        /// </summary>
        /// <param name="exp">Property name</param>
        /// <returns></returns>
        public NullableNumberOperation<TParent, double?> Property(Expression<Func<T, double?>> exp)
        {
            return new NullableNumberOperation<TParent, double?>(_collectionName, ExpressionHelper.GetName(exp), _operator, _filter);
        }
    }
}
