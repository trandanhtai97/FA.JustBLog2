using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Web.Mvc;


namespace FA.JustBlog.WebMVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentServices _commentServices;
        private readonly IPostServices _postServices;

        public CommentController(CommentServices commentServices, PostServices postServices)
        {
            _commentServices = commentServices;
            _postServices = postServices;
        }

        // GET: Comment
        public ActionResult Index(Guid id)
        {
            var comments = _commentServices.GetCommentsForPost(id);
            return PartialView("_ShowComments", comments);
        }

        [HttpPost]
        public JsonResult AddComment(Guid postId ,string name, string email, string commentHeader, string commentText)
        {
            var comment = new Comment();
            comment.Id = Guid.NewGuid();
            comment.Name = name;
            comment.Email = email;
            comment.CommentHeader = commentHeader;
            comment.CommentText = commentText;
            comment.CommentTime = DateTime.Now;
            comment.PostId = postId;

            _commentServices.Add(comment);

            return Json(new { comment.Name, comment.CommentHeader, comment.CommentText, comment.CommentTime }, JsonRequestBehavior.AllowGet);
        }
    }
}