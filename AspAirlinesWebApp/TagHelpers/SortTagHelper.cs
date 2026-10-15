using AspAirlinesWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspAirlinesWebApp.TagHelpers
{
    public class SortTagHelper : TagHelper
    {
        public SortState Current { get; set; }
        public SortState Property { get; set; }
        public string? Action { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;

        IUrlHelperFactory urlHelperFactory;

        public SortTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            
            output.TagName = "a";
            string? url = urlHelper.Action(Action, new { sortState = Property });

            output.Attributes.SetAttribute("href", url);
        }
    }
}
