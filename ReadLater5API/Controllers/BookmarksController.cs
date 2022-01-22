using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadLater5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        IBookmarkService _bookmarkService;

        public BookmarksController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        // GET: api/<BookmarksController>
        [HttpGet]
        public IEnumerable<Bookmark> Get()
        {
            return _bookmarkService.GetBookmarks();
        }

        // GET api/<BookmarksController>/5
        [HttpGet("{id}")]
        public Bookmark Get(int id)
        {
            return _bookmarkService.GetBookmark(id);
        }

        // POST api/<BookmarksController>
        [HttpPost]
        public void Post(Bookmark bookmark)
        {
            _bookmarkService.CreateBookmark(bookmark);
        }

        // PUT api/<BookmarksController>/5
        [HttpPut("{id}")]
        public void Put(/*int id, */Bookmark bookmark)
        {
            _bookmarkService.UpdateBookmark(bookmark);
        }

        // DELETE api/<BookmarksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark(id);
            if (bookmark != null)
                _bookmarkService.DeleteBookmark(bookmark);
        }
    }
}
