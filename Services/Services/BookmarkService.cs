using Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class BookmarkService : IBookmarkService
    {
        private ReadLaterDataContext _readLaterDataContext;

        public BookmarkService(ReadLaterDataContext readLaterDataContext)
        {
            _readLaterDataContext = readLaterDataContext;
        }

        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            _readLaterDataContext.Bookmarks.Add(bookmark);
            _readLaterDataContext.SaveChanges();
            return bookmark;
        }

        public void DeleteBookmark(Bookmark bookmark)
        {
            _readLaterDataContext.Remove(bookmark);
            _readLaterDataContext.SaveChanges();
        }

        public Bookmark GetBookmark(int? id, string userId)
        {
            return _readLaterDataContext.Bookmarks.Where(b => b.ID == id && b.AspNetUserId == userId).Include(b => b.Category).FirstOrDefault();
        }

        public List<Bookmark> GetBookmarks(string userId)
        {
            return _readLaterDataContext.Bookmarks.Where(b => b.AspNetUserId == userId).Include(b => b.Category).ToList();
        }

        public List<Bookmark> GetBookmarks(DateTime fromDate, DateTime toDate, string userId)
        {
            return _readLaterDataContext.Bookmarks.Where(b => b.CreateDate.Date >= fromDate && b.CreateDate.Date <= toDate && b.AspNetUserId == userId).Include(b => b.Category).ToList();
        }

        public List<Bookmark> GetBookmarks(int categoryId, string userId)
        {
            return _readLaterDataContext.Bookmarks.Where(b => b.CategoryId == categoryId && b.AspNetUserId == userId).Include(b => b.Category).ToList();
        }

        public void UpdateBookmark(Bookmark bookmark)
        {
            _readLaterDataContext.Update(bookmark);
            _readLaterDataContext.SaveChanges();
        }
    }
}
