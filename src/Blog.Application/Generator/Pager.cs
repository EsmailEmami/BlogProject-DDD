using Blog.Application.ViewModels;

namespace Blog.Application.Generator;

public static class Pager
{
    private static int _showVisiblePages = 3;
    public static int ShowVisiblePages
    {
        get => _showVisiblePages;
        set
        {
            _showVisiblePages = value;
            if (_showVisiblePages <= 0)
            {
                _showVisiblePages = 3;
            }
        }
    }

    public static BasePaging Build(int pagesCount, int pageNumber, int take)
    {
        if (pageNumber <= 1) pageNumber = 1;


        BasePaging paging = new BasePaging();
        paging.SetPage(pageNumber, pagesCount, take, _showVisiblePages);
        return paging;
    }
}