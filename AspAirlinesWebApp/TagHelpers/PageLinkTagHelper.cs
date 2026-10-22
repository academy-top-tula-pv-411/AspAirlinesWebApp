using AspAirlinesWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing.Printing;

namespace AspAirlinesWebApp.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        // 
        public string Action { get; set; }
        public PageViewModel Model { get; set; }

        //
        public SortState SortState { get; set; }
        public int Airline { get; set; }
        public int Airport { get; set; }


        IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            output.TagName = "div";

            TagBuilder ulTag = new("ul");
            ulTag.AddCssClass("pagination");

            var prev = UlItemCreate(Model.ActivePage - 1, "Previous", urlHelper);
            prev.AddCssClass(Model.HasPrev ? "" : "disabled");
            ulTag.InnerHtml.AppendHtml(prev);

            for (int i = 1; i <= Model.PageCount; i++)
                ulTag.InnerHtml.AppendHtml(UlItemCreate(i, i.ToString(), urlHelper));

            var next = UlItemCreate(Model.ActivePage + 1, "Next", urlHelper);
            next.AddCssClass(Model.HasNext ? "" : "disabled");
            ulTag.InnerHtml.AppendHtml(next);

            output.Content.AppendHtml(ulTag);
        }

        private TagBuilder UlItemCreate(int pageNumber, string pageTitle, IUrlHelper urlHelper)
        {
            TagBuilder liTag = new("li");
            liTag.AddCssClass("page-item");
            liTag.AddCssClass(Model.ActivePage == pageNumber ? "active" : "");
            
            TagBuilder aTag = new("a");
            aTag.InnerHtml.Append(pageTitle);
            aTag.AddCssClass("page-link");
            
            aTag.Attributes.Add("href", urlHelper.Action(Action, new
                {
                    sortState = SortState,
                    airline = Airline,
                    airport = Airport,
                    page = pageNumber,
                    pageSize = Model.PageSize,
                }));

            liTag.InnerHtml.AppendHtml(aTag);

            return liTag;
        }

    }
}
