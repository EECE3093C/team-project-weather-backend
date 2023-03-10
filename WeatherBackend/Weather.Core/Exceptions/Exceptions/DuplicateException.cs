using System;
using System.Diagnostics.CodeAnalysis;

namespace CIberSuiteCloud.Core.Exceptions
{
    [ExcludeFromCodeCoverage]
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
