using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entity;
using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ReadLater5.Controllers
{
    [Authorize]
    public class BookmarksController : Controller
    {
        IBookmarkService _bookmarkService;
        ICategoryService _categoryService;
        private readonly UserManager<IdentityUser> _userManager;

        public BookmarksController(IBookmarkService bookmarkService, ICategoryService categoryService, UserManager<IdentityUser> userManager)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        // GET: Bookmarks
        public IActionResult Index()
        {
            List<Bookmark> bookmarks = _bookmarkService.GetBookmarks(_userManager.GetUserId(User));
            return View(bookmarks);
        }

        // GET: Bookmarks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bookmark bookmark = _bookmarkService.GetBookmark(id, _userManager.GetUserId(User));
            if (bookmark == null)
            {
                return NotFound();
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Create
        public IActionResult Create()
        {
            ViewData["AspNetUserId"] = _userManager.GetUserId(User);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(_userManager.GetUserId(User)), "ID", "Name");
            return View();
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.CreateBookmark(bookmark);
                return RedirectToAction(nameof(Index));
            }

            ViewData["AspNetUserId"] = _userManager.GetUserId(User);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(_userManager.GetUserId(User)), "ID", "Name", bookmark.CategoryId);
            return View(bookmark);
        }

        // GET: Bookmarks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bookmark bookmark = _bookmarkService.GetBookmark(id, _userManager.GetUserId(User));

            if (bookmark == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(_userManager.GetUserId(User)), "ID", "Name", bookmark.CategoryId);
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Bookmark bookmark)
        {
            if (id != bookmark.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(bookmark);

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(_userManager.GetUserId(User)), "ID", "Name", bookmark.CategoryId);
            return View(bookmark);
        }

        // GET: Bookmarks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bookmark bookmark = _bookmarkService.GetBookmark(id, _userManager.GetUserId(User));
            if (bookmark == null)
            {
                return NotFound();
            }

            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark(id, _userManager.GetUserId(User));
            if (bookmark == null)
                return NotFound();

            _bookmarkService.DeleteBookmark(bookmark);
            return RedirectToAction(nameof(Index));
        }

        //[ChildActionOnly]
        [HttpGet, ActionName("AddNewCategoryPartial")]
        public ActionResult AddNewCategoryPartial(string categoryName, string userId)
        {
            _categoryService.CreateCategory(new Category() { Name = categoryName, AspNetUserId = userId });
            ViewData["AspNetUserId"] = userId;
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(_userManager.GetUserId(User)), "ID", "Name");
            return PartialView("_SelectCategoryPartial");
        }
    }
}
