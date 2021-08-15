using FA.JustBlog.Services;
using System.Linq;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagServices _tagServices;

        public TagController(ITagServices tagServices)
        {
            _tagServices = tagServices;
        }

        // GET: Tag
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PopularTags()
        {
            var tags = _tagServices.GetAll().Take(10);
            return PartialView("_PopularTags", tags);
        }
    }
}