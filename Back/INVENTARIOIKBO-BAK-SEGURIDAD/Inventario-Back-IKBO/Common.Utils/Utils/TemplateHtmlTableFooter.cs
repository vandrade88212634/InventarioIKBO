using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class TemplateHtmlTableFooter
    {
        public TemplateHtmlTableFooter()
        {
            DynamicColumns = new Dictionary<string, List<string>>();
            FixedColumns = new Dictionary<string, string>();
        }
        public Dictionary<string, List<string>> DynamicColumns { get; set; }
        public Dictionary<string, string> FixedColumns { get; set; }
    }
}
