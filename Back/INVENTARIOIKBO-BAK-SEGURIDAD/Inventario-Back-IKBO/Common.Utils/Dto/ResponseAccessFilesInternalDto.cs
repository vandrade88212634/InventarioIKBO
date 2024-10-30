using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class ResponseAccessFilesInternalDto
    {
        public bool IsSuccess { get; set; }
        public Exception Error { get; set; }
        public string Message { get; set; }
        public ResponseDataInternalFileDto Data { get; set; }
    }
}
