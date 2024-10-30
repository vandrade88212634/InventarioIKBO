using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class CompanyResponseDto
    {
        public int CompanyId { get; set; }
        public string Nit { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string ShortName { get; set; }
    }
}