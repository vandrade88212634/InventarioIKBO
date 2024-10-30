using System.Diagnostics.CodeAnalysis;


namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class RequestAccesFileInternalDto
    {
        public string Path { get; set; }
        public List<string> PrefixSearch { get; set; }
    }
}
