using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Utils
{
    [ExcludeFromCodeCoverage]
    public class SetDynamicTableDto
    {
        public string body { set; get; }
        public List<object> requestSubmit { set; get; }
        public Type typeDto { set; get; }
        public string numberTable { set; get; }
    }
}
