using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ReadLater5API.Helpers;
using ReadLater5API.Models.DTOs.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadLater5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookmarksController : ControllerBase
    {
        IBookmarkService _bookmarkService;
        ICategoryService _categoryService;
        IJwtHelper _jwtHelper;

        public BookmarksController(IBookmarkService bookmarkService, ICategoryService categoryService, IJwtHelper jwtHelper)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
            _jwtHelper = jwtHelper;
        }

        // GET: api/<BookmarksController>
        [HttpGet]
        public IEnumerable<Bookmark> Get()
        {
            string userId = _jwtHelper.GetUserIdFromToken(HttpContext.Request.Headers["Authorization"]);
            return _bookmarkService.GetBookmarks(userId);
        }

        // GET api/<BookmarksController>/5
        [HttpGet("{id}")]
        public Bookmark Get(int id)
        {
            string userId = _jwtHelper.GetUserIdFromToken(HttpContext.Request.Headers["Authorization"]);
            return _bookmarkService.GetBookmark(id, userId);
        }

        // POST api/<BookmarksController>
        [HttpPost]
        public void Post(Bookmark bookmark)
        {
            string userId = _jwtHelper.GetUserIdFromToken(HttpContext.Request.Headers["Authorization"]);
            if(ModelState.IsValid && bookmark.AspNetUserId == userId)
                _bookmarkService.CreateBookmark(bookmark);
        }

        // PUT api/<BookmarksController>/5
        [HttpPut]
        public void Put(Bookmark bookmark)
        {
            string userId = _jwtHelper.GetUserIdFromToken(HttpContext.Request.Headers["Authorization"]);
            if(ModelState.IsValid && bookmark.AspNetUserId == userId)
                _bookmarkService.UpdateBookmark(bookmark);
        }

        // DELETE api/<BookmarksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string userId = _jwtHelper.GetUserIdFromToken(HttpContext.Request.Headers["Authorization"]);
            Bookmark bookmark = _bookmarkService.GetBookmark(id, userId);
            if (bookmark != null)
                _bookmarkService.DeleteBookmark(bookmark);
        }

        
    }
}
