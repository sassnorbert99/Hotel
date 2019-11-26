using System;
using System.Runtime.Serialization;

namespace HotelLite
{
    [Serializable]
    internal class bedsException : Exception
    {
        public bedsException()
        {
        }

        public bedsException(string message) : base(message)
        {
        }

        public bedsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected bedsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}