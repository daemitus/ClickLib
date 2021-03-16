using System;

namespace ClickLib
{
    public class InvalidClickException : InvalidOperationException
    {
        public InvalidClickException(string message) : base(message) { }

        public InvalidClickException(string message, Exception innerException) : base(message, innerException) { }
    }
}
