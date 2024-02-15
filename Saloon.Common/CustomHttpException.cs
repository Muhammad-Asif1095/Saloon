using System;
using System.Net;

namespace Saloon.Common
{

    [Serializable]
    public class CustomHttpException : Exception
    {
        public HttpStatusCode HttpCode { get; }

        public CustomHttpException() { }

        public CustomHttpException(string message)
            : base(message) { }

        public CustomHttpException(string message, Exception inner)
            : base(message, inner) { }

        public CustomHttpException(string message, HttpStatusCode _HttpCode)
            : this(message)
        {
            HttpCode = _HttpCode;
        }
    }
}
