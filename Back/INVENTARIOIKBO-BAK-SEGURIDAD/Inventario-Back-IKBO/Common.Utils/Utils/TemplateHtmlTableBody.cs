using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class TemplateHtmlTableBody
    {
        public TemplateHtmlTableBody()
        {
            FixedColumns = new Dictionary<string, string>();
            DynamicColumns = new Dictionary<string, List<string>>();
        }
        public Dictionary<string, string> FixedColumns { get; set; }
        public Dictionary<string, List<string>> DynamicColumns { get; set; }
    }
}
