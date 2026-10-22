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
        // sort attributes
        public SortState Current { get; set; }
        public SortState Property { get; set; }
        public string? Action { get; set; }


        // others attributes
        public int Airline { get; set; }
        public int Airport { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }


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
            string? url = urlHelper.Action(Action, 
                new 
                { 
                    sortState = Property,
                    airline = Airline,
                    airport = Airport,
                    page = Page,
                    pageSize = PageSize,
                });

            output.Attributes.SetAttribute("href", url);
        }
    }
}
