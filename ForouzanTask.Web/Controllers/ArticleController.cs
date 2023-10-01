using ForouzanTask.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForouzanTask.Web.Controllers
{
    public class ArticleController : BaseController
    {
        private IArticleAdminService _article;
        public ArticleController(IArticleAdminService article)
        {
            _article = article;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ShowArticle(Guid id)
        {
            var article = await _article.GetArticleById(id);
            return View(article);
        }
    }
}
