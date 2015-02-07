using System;

namespace PoroLib.Forwarder
{
    public class NotConnectedException: Exception
    {
        public NotConnectedException()
            : base() { }

        public NotConnectedException(string message)
            : base(message) { }

        public NotConnectedException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public NotConnectedException(string message, Exception innerException)
            : base(message, innerException) { }

        public NotConnectedException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
