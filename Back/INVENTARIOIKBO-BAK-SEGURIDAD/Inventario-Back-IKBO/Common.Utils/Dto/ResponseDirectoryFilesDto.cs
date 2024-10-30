using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class ResponseDirectoryFilesDto
    {
        public bool IsSuccess { get; set; }
        public Exception Error { get; set; }
        public string Message { get; set; }
        public List<string> Data { get; set; }
    }
}
