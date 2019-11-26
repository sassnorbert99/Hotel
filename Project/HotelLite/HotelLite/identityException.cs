using System;
using System.Runtime.Serialization;

namespace HotelLite
{
    [Serializable]
    internal class identityException : Exception
    {
        public identityException()
        {
        }

        public identityException(string message) : base(message)
        {
        }

        public identityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected identityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}