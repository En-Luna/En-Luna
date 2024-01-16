using X.PagedList.Web.Common;

namespace En_Luna.Helpers
{
    public static class HtmlHelper
    {
        public static PagedListRenderOptions PagedListRenderOptions
            => new PagedListRenderOptions
            {
                LiElementClasses = new string[] { "page-item" },
                PageClasses = new string[] { "page-link" },
                DisplayLinkToFirstPage = PagedListDisplayMode.IfNeeded,
                DisplayLinkToLastPage = PagedListDisplayMode.IfNeeded,
                MaximumPageNumbersToDisplay = 5,
                DisplayEllipsesWhenNotShowingAllPageNumbers = true,
            };
    }
}
