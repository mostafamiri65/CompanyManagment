using ForouzanTask.Application.DTOs.Article;
using ForouzanTask.Application.DTOs.User;
using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace ForouzanTask.Application.Services.Implementations
{
    public class HomeService : IHomeService
    {
       private readonly ForouzanTaskContext _context;
        public HomeService(ForouzanTaskContext context)
        {
            _context = context;
        }

        public async Task<List<ArticleListDto>> GetArticleList()
        {
            var articles = await _context.TbArticles.Where(a => !a.IsDelete && 
            a.IsApproal).ToListAsync();
            List<ArticleListDto> list = new List<ArticleListDto>();
            foreach (var article in articles)
            {
                var user = await _context.TbUsers
                    .SingleOrDefaultAsync(u => u.Id == article.CreateUserId);
                var category = await _context.TbCategories.SingleOrDefaultAsync(c =>
                c.Id == article.CategoryId);
                ArticleListDto articleListDto = new ArticleListDto();
                articleListDto.Id = article.Id;
                articleListDto.Title = article.Title;
                articleListDto.CreateDate = article.CreateDate;
                if (user != null)
                    articleListDto.CreatedBy = user;
                if (article.MainImageName != null)
                    articleListDto.MainImageName = article.MainImageName;
                if (article.ShortDescription != null)
                    articleListDto.ShortDescription = article.ShortDescription;
                articleListDto.IsApproal = article.IsApproal;
                if (article.MetaDescription != null)
                    articleListDto.MetaDescription = article.MetaDescription;
                articleListDto.IsShown = article.IsShown;
                if (article.SliderPicture != null)
                    articleListDto.SliderPicture = article.SliderPicture;
                if (category != null)
                    articleListDto.Category = category;
                list.Add(articleListDto);
            }
            return list;
        }

      
    }
}
