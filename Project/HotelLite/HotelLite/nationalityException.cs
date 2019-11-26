using System;
using System.Runtime.Serialization;

namespace HotelLite
{
    [Serializable]
    internal class nationalityException : Exception
    {
        public nationalityException()
        {
        }

        public nationalityException(string message) : base(message)
        {
        }

        public nationalityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected nationalityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}