using FA.JustBlog.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostServices _postServices;

        public HomeController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var posts = await _postServices.GetAllAsync();
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}