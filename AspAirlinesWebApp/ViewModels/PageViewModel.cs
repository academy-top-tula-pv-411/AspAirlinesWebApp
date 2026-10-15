namespace AspAirlinesWebApp.ViewModels
{
    public class PageViewModel
    {
        public int ActivePage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public bool HasPrev => ActivePage > 1;
        public bool HasNext => ActivePage < PageCount;

        public PageViewModel(int activePage, int pageSize, int flightsCount)
        {
            ActivePage = activePage;
            PageSize = pageSize;

            PageCount = (int)Math.Ceiling(flightsCount / (double)pageSize);
        }
    }
}
