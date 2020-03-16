using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TypeSearch
{
    /// <summary>
    /// The exception that is thrown when an unsupported expression type is encountered
    /// </summary>
    class UnsupportedExpressionTypeException : Exception
    {
        public UnsupportedExpressionTypeException()
        {
        }

        public UnsupportedExpressionTypeException(string message) : base(message)
        {
        }

        public UnsupportedExpressionTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnsupportedExpressionTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
