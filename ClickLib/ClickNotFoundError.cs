using System;

namespace ClickLib
{
    public class ClickNotFoundError : InvalidOperationException
    {
        public ClickNotFoundError(string message) : base(message) { }
    }
}
