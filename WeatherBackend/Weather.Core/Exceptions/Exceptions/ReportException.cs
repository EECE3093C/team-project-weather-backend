using System;
using System.Diagnostics.CodeAnalysis;

namespace CIberSuiteCloud.Core.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ReportException : Exception
    {
        public ReportException(string message) : base(message)
        {
        }

        public ReportException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
