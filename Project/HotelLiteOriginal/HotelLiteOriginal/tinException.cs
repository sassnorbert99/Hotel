using System;
using System.Runtime.Serialization;

namespace HotelLite
{
    [Serializable]
    internal class tinException : Exception
    {
        public tinException()
        {
        }

        public tinException(string message) : base(message)
        {
        }

        public tinException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected tinException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}