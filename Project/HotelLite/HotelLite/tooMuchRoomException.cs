using System;
using System.Runtime.Serialization;

namespace HotelLite
{
    [Serializable]
    internal class tooMuchRoomException : Exception
    {
        public tooMuchRoomException()
        {
        }

        public tooMuchRoomException(string message) : base(message)
        {
        }

        public tooMuchRoomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected tooMuchRoomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}