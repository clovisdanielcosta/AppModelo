using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CD.UI.Site.Extensions
{
    public class EmailComercialTagHelper : TagHelper
    {
        public string EmailDomain { get; set; } = "sales.com.br";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}
