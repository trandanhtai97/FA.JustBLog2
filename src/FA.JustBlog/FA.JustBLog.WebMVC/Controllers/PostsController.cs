﻿using FA.JustBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostServices _postServices;
        private readonly ICategoryServices _categoryServices;

        public PostsController(IPostServices postServices, ICategoryServices categoryServices)
        {
            _postServices = postServices;
            _categoryServices = categoryServices;
        }
        // GET: Posts
        public async Task<ActionResult> Index()
        {
            var allPosts = await _postServices.GetAllAsync();
            return View(allPosts);
        }

        public ActionResult LastestPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetLatestPostAsync(5)).Result;
            ViewBag.PartialViewTitle = "Lastest Posts";
            return PartialView("_ListPost", lastestPosts);
        }

        public ActionResult MostViewPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetMostViewPostsAsync(5)).Result;
            ViewBag.PartialViewTitle = "Most View Posts";
            return PartialView("_PopularPosts", lastestPosts);
        }

        public ActionResult HighestPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetMostViewPostsAsync(5)).Result;
            ViewBag.PartialViewTitle = "Highest Posts";
            return PartialView("_ListPost", lastestPosts);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var post = await _postServices.GetByIdAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public async Task<ActionResult> Details(int year, int month, string urlSlug)
        {
            var post = await _postServices.GetPostsByDateAndUrlSlugAsync(year, month, urlSlug);
            return View(post);
        }
      
    }
}