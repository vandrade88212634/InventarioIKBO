using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class ContenResponseDto<T> where T : class
    {
        public bool estado { get; set; }
        public string mensaje { get; set; }
        public T resultado { get; set; }
    }
}