﻿using Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            bookmark.CreateDate = DateTime.Now;
            _readLaterDataContext.Bookmarks.Add(bookmark);
            _readLaterDataContext.SaveChanges();
            return bookmark;
        }

        public void DeleteBookmark(Bookmark bookmark)
        {
            _readLaterDataContext.Remove(bookmark);
            _readLaterDataContext.SaveChanges();
        }

        public Bookmark GetBookmark(int? id)
        {
            return _readLaterDataContext.Bookmarks.Where(b => b.ID == id).Include(b => b.Category).FirstOrDefault();
        }

        public List<Bookmark> GetBookmarks()
        {
            return _readLaterDataContext.Bookmarks.Include(b => b.Category).ToList();
        }

        public List<Bookmark> GetBookmarks(DateTime fromDate, DateTime toDate)
        {
            return _readLaterDataContext.Bookmarks.Where(b => b.CreateDate.Date >= fromDate && b.CreateDate.Date <= toDate).Include(b => b.Category).ToList();
        }

        public List<Bookmark> GetBookmarks(int categoryId)
        {
            return _readLaterDataContext.Bookmarks.Where(b => b.CategoryId == categoryId).Include(b => b.Category).ToList();
        }

        public void UpdateBookmark(Bookmark bookmark)
        {
            _readLaterDataContext.Update(bookmark);
            _readLaterDataContext.SaveChanges();
        }
    }
}
