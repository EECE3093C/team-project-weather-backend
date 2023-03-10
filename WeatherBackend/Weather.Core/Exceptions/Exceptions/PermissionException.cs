using System;
using System.Diagnostics.CodeAnalysis;

namespace CIberSuiteCloud.Core.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class PermissionException : Exception
    {
        public PermissionException(string message) : base(message)
        {
        }

        public PermissionException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
