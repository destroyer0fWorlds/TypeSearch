using System;
using System.Linq;
using System.Linq.Expressions;

namespace TypeSearch
{
    /// <summary>
    /// Utility for interacting with <see cref="System.Linq.Expressions.Expression{TDelegate}"/>
    /// </summary>
    class ExpressionHelper
    {
        /// <summary>
		/// Get the property name used for the expression
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="exp">Property expression</param>
		/// <returns>Field name</returns>
		public static string GetName<T, TResult>(Expression<Func<T, TResult>> exp)
        {
            MemberExpression memberExpression = null;

            switch (exp.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    memberExpression = (MemberExpression)exp.Body;
                    break;
                case ExpressionType.Convert:
                    var unaryExpression = (UnaryExpression)exp.Body;
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                    break;
            }

            return memberExpression.Member.Name;
        }
    }
}
