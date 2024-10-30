using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Ideam.Sirlab.WebApi.Models.General
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class HttpResponseException : Exception
    {
        public HttpResponseException()
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int Status { get; set; }

        public object Value { get; set; }
    }
}