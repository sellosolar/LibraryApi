using System;

namespace Library.Core.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException()
        {

        }

        public CustomException(string message) : base(message)
        {

        }
    }
}
