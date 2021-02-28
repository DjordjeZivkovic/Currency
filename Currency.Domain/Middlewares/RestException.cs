using System;
using System.Net;

namespace Currency.Domain.Middlewares
{
    public class RestException : Exception
    {
        public HttpStatusCode Code;
        public object Error;

        public RestException(HttpStatusCode code, object error = null)
        {
            Code = code;
            Error = error;
        }
    }
}
