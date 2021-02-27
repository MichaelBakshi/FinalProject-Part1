using System;
using System.Runtime.Serialization;

namespace FinalProject_Part1
{
    [Serializable]
    internal class WrongLevelOfAccessException : Exception
    {
        public WrongLevelOfAccessException()
        {
        }

        public WrongLevelOfAccessException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public WrongLevelOfAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongLevelOfAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}