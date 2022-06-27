namespace Blog.Application.ViewModels;

public class BasePaging
{
    public int PageId { get; private set; } = 1;
    public int PagesCount { get; private set; }
    public int ActivePage { get; private set; }
    public int StartPage { get; private set; }
    public int EndPage { get; private set; }
    public int TakeEntity { get; private set; } = 10;
    public int SkipEntity { get; private set; }

    public void SetPage(int pageNumber, int pagesCount, int take, int showVisiblePages)
    {
        ActivePage = pageNumber;
        PagesCount = pagesCount;
        PageId = pageNumber;
        TakeEntity = take;
        SkipEntity = (pageNumber - 1) * take;
        StartPage = pageNumber - showVisiblePages <= 0 ? 1 : pageNumber - showVisiblePages;
        EndPage = pageNumber + showVisiblePages > pagesCount ? pagesCount : pageNumber + showVisiblePages;
    }

    public void SetPage(BasePaging paging)
    {
        PageId = paging.PageId;
        PagesCount = paging.PagesCount;
        StartPage = paging.StartPage;
        EndPage = paging.EndPage;
        TakeEntity = paging.TakeEntity;
        SkipEntity = paging.SkipEntity;
        ActivePage = paging.ActivePage;
    }
}