using System;
using System.Runtime.Serialization;

namespace HotelLite
{
    [Serializable]
    internal class priceLessException : Exception
    {
        public priceLessException()
        {
        }

        public priceLessException(string message) : base(message)
        {
        }

        public priceLessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected priceLessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}