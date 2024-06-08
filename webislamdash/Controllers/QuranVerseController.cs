using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webislamdash.Services;
using webislamdash.Models;
using System.Threading.Tasks;
using webislamdash.Data;
using Microsoft.EntityFrameworkCore;

namespace webislamdash.Controllers
{
    public class QuranController : Controller
    {
        private readonly QuranApiService _quranApiService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public QuranController(QuranApiService quranApiService, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _quranApiService = quranApiService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index(int pageNumber)
        {
            var quranPage = await _quranApiService.FetchPage(pageNumber);
            return PartialView("~/Views/Home/_QuranPage.cshtml", quranPage);
        }

        [HttpPost]
        public async Task<IActionResult> Bookmark([FromBody] BookmarkModel model)
        {
            var userId = _userManager.GetUserId(User);
            var bookmark = new Bookmark
            {
                UserId = userId,
                PageNumber = model.PageNumber
            };

            _context.Bookmarks.Add(bookmark);
            await _context.SaveChangesAsync();

            return Ok();
        }

        public class BookmarkModel
        {
            public int PageNumber { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBookmark([FromBody] BookmarkModel model)
        {
            var userId = _userManager.GetUserId(User);
            var bookmark = await _context.Bookmarks
                .FirstOrDefaultAsync(b => b.UserId == userId && b.PageNumber == model.PageNumber);

            if (bookmark != null)
            {
                _context.Bookmarks.Remove(bookmark);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetBookmarks()
        {
            var userId = _userManager.GetUserId(User);
            var bookmarks = await _context.Bookmarks
                .Where(b => b.UserId == userId)
                .Select(b => b.PageNumber)
                .ToListAsync();

            return Ok(bookmarks);
        }
    }
}