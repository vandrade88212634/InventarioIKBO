using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class TemplateHtmlTableHeader
    {
        public TemplateHtmlTableHeader()
        {
            DynamicColumns = new Dictionary<string, List<string>>();
        }
        public Dictionary<string, List<string>> DynamicColumns { get; set; }
    }
}
