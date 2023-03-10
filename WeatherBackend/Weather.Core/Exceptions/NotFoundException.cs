using System;
using System.Diagnostics.CodeAnalysis;

namespace Weather.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        //public NotFoundException() : base()
        //{
        //}

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
