using System;
using System.Diagnostics.CodeAnalysis;

namespace Weather.Core.Exceptions
{
    public class DuplicateException : Exception
    {
        //public DuplicateException()
        //{
        //}

        public DuplicateException(string message) : base(message)
        {
        }

        public DuplicateException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
