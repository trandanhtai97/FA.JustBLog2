using FA.JustBlog.Services;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public ActionResult Index()
        {
            var categories = _categoryServices.GetAll();
            return PartialView("_MenuCategory", categories);
        }
    }
}