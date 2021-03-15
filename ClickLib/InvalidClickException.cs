using System;

namespace ClickLib
{
    public class InvalidClickException : InvalidOperationException
    {
        public InvalidClickException(string message) : base(message) { }
    }
}
