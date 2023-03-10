using System;
using System.Diagnostics.CodeAnalysis;

namespace CIberSuiteCloud.Core.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message) : base(message)
        {
        }

        public BusinessRuleException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
