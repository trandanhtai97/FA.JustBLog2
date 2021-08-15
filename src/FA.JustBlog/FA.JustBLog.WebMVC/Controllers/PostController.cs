using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostServices _postServices;

        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string currentFilter, string searchString,
            int? pageIndex = 1, int pageSize = 4)
        {

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            Expression<Func<Post, bool>> filter = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = p => p.Title.Contains(searchString);
            }

            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = q => q.OrderByDescending(c => c.PostedOn);

            var posts = await _postServices.GetAsync(filter: filter, orderBy: orderBy, pageIndex: pageIndex ?? 1, pageSize: pageSize);

            return View(posts);
        }

        public async Task<ActionResult> Detail(Guid id)
        {
            var post = await _postServices.GetByIdAsync(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            post.ViewCount++;
            await _postServices.UpdateAsync(post);

            return View(post);
        }

        public async Task<ActionResult> Details(int year, int month, string urlSlug)
        {
            var post = await _postServices.FindPostAsync(year, month, urlSlug);

            if (post == null)
            {
                return HttpNotFound();
            }

            post.ViewCount++;
            await _postServices.UpdateAsync(post);

            return View("Detail", post);
        }

        public ActionResult LastestPost()
        {
            var posts = _postServices.GetLatestPost(3);
            return PartialView("_LastestPost", posts);
        }

        public ActionResult MostViewedPost()
        {
            var posts = _postServices.GetMostViewedPost(5);
            return PartialView("_MostViewedPost", posts);
        }

        public async Task<ActionResult> GetPostByCategory(string category)
        {
            var posts = await _postServices.GetPostsByCategoryAsync(category);
            return View(posts);
        }

        public async Task<ActionResult> GetPostByTag(string tag)
        {
            var posts = await _postServices.GetPostsByTagAsync(tag);
            return View(posts);
        }
    }
}