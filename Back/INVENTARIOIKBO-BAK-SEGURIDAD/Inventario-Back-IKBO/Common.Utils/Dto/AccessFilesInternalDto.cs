using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class AccessFilesInternalDto
    {
        public string FileBase64 { get; set; }

        public string FileName { get; set; }
    }
}
