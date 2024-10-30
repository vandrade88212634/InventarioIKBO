using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class ResponseDataInternalFileDto
    {
        public string FileBase64 { get; set; }
        public string FileName { get; set; }
    }
}
