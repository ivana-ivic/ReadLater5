using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookmarkService
    {
        Bookmark GetBookmark(int? id);
        List<Bookmark> GetBookmarks();
        List<Bookmark> GetBookmarks(DateTime fromDate, DateTime toDate);
        List<Bookmark> GetBookmarks(int categoryId);
        Bookmark CreateBookmark(Bookmark bookmark);
        void UpdateBookmark(Bookmark bookmark);
        void DeleteBookmark(Bookmark bookmark);
    }
}
