using System;

namespace Ensure.Core.Ensure
{
    public class EnsureException : Exception
    {
        public EnsureException(string message) : base(message) { }
        public EnsureException(string message, Exception inner) : base(message, inner) { }
    }
}