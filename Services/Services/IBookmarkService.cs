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
        Bookmark GetBookmark(int? id, string userId);
        List<Bookmark> GetBookmarks(string userId);
        List<Bookmark> GetBookmarks(DateTime fromDate, DateTime toDate, string userId);
        List<Bookmark> GetBookmarks(int categoryId, string userId);
        Bookmark CreateBookmark(Bookmark bookmark);
        void UpdateBookmark(Bookmark bookmark);
        void DeleteBookmark(Bookmark bookmark);
    }
}
