using ForouzanTask.Application.DTOs.Article;
using ForouzanTask.Application.Extensions;
using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.DataLayer.Entities.Article;
using Microsoft.AspNetCore.Mvc;

namespace ForouzanTask.Web.Areas.Admin.Controllers
{
    public class ArticleAdminController : BaseAdminController
    {
        private IArticleAdminService _article;
        public ArticleAdminController(IArticleAdminService article)
        {
            _article = article;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _article.GetArticleList();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> CreateArticle()
        {
            ViewData["Categories"] = await _article.GetCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleDto create)
        {
            var article = await _article.AddArticle(create, User.GetUserId());
            if (article == Guid.Empty)
            {
                TempData[ErrorMessage] = "فایل می بایست با پسوند عکس باشد";
                ViewData["Categories"] = await _article.GetCategories();
                return View();
            }
        
            return RedirectToAction("ShowDetails", new { articleId = article});
        }
        public async Task<IActionResult> ShowDetails(Guid articleId)
        {
            var subs = await _article.GetSubArticles(articleId);
            ViewData["Subs"] = subs;
            var article = await _article.GetArticleById(articleId);
            return View(article);
        }
        [HttpGet]
        public async Task<IActionResult> AddSub(Guid id)
        {
            var article = await _article.GetArticleById(id);
            ViewData["Article"] = article;
            ViewBag.Num = await _article.GetNumOfParagraphForSubArticle(id);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSub(CreateSubArticleDto subArticle,IFormFile pic)
        {
            subArticle.Picture = pic;
            if(!await _article.IsTheNumOfParagraphOK(subArticle.ArticleId, subArticle.NumberOfParagraph))
            {
                TempData[ErrorMessage] = "شماره پاراگراف وارد شده صحیح نیست.";
                 return RedirectToAction("ShowDetails", new { articleId = subArticle.ArticleId }); ;
            }
           var result = await _article.AddSubArticle(subArticle, User.GetUserId());
            if (!result)
            {
                TempData[ErrorMessage] = "عکس وارد شده با پسوند عکس نیست. عملیات انجام نشد";
                return RedirectToAction("ShowDetails", new { articleId = subArticle.ArticleId }); ;
            }
           
            return RedirectToAction("ShowDetails", new { articleId = subArticle.ArticleId });
        }
    }
}
