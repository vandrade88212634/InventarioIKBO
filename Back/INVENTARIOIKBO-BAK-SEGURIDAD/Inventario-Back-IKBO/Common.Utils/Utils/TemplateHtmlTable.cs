using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class TemplateHtmlTable
    {
        public TemplateHtmlTable()
        {
            Header = new TemplateHtmlTableHeader();
            Rows = new List<TemplateHtmlTableBody>();
            Footer = new TemplateHtmlTableFooter();
        }

        public TemplateHtmlTableHeader Header { get; set; }
        public List<TemplateHtmlTableBody> Rows { get; set; }
        public TemplateHtmlTableFooter Footer { get; set; }
    }
}
