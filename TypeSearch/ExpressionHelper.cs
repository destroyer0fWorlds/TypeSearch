using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
            try
            {
                var memberNames = new List<string>();
                GetNameRecursively(exp.Body, memberNames);
                return string.Join(".", memberNames);
            }
            catch (UnsupportedExpressionTypeException)
            {
                throw new InvalidOperationException($"Invalid expression '{exp}'. Expressions must be of type {ExpressionType.MemberAccess} or {ExpressionType.Convert}.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the member name(s) by recursively traversing the expression tree
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="memberNames"></param>
        private static void GetNameRecursively(Expression exp, List<string> memberNames)
        {
            MemberExpression memberExpression = null;

            switch (exp.NodeType)
            {
                case ExpressionType.MemberAccess:
                    memberExpression = (MemberExpression)exp;
                    break;
                case ExpressionType.Convert:
                    var unaryExpression = (UnaryExpression)exp;
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                    break;
                default:
                    throw new UnsupportedExpressionTypeException();
            }

            if (memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
            {
                GetNameRecursively(memberExpression.Expression, memberNames);
            }
            memberNames.Add(memberExpression.Member.Name);
        }
    }
}
