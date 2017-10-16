using System;

namespace Ensure.Core.Ensure
{
    public class EnsureException : System.Exception
    {
        public EnsureException() { }
        public EnsureException(string message) : base(message) { }
        public EnsureException(string message, System.Exception inner) : base(message, inner) { }
        protected EnsureException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}