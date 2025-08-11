using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, object? value = null) =>
            (this.StatusCode, this.Value) = (statusCode, value);

        public int StatusCode { get; }

        public object Value { get; }

        protected HttpResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
