using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Jarvus.TagHelpers
{
    public class DumpTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public object For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "pre";    // Replaces <dump> with <div> tag
            output.Content.SetHtmlContent(Json.SerializeObject(For));
        }
    }
}