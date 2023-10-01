using ForouzanTask.Application.DTOs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.Services.Interfaces
{
    public interface IArticleAdminService
    {
        Task<List<ArticleListDto>> GetArticleList();
        Task<Guid> AddArticle(CreateArticleDto createArticleDto,Guid userId);
        Task<List<CategoryListDto>> GetCategories();
        Task<ArticleDto?> GetArticleById(Guid id);
        Task<bool> AddSubArticle(CreateSubArticleDto createSubArticle,Guid userId);
        Task<List<SubArticleDto>> GetSubArticles(Guid articleId);
        Task<int> GetNumOfParagraphForSubArticle(Guid articleId);
        Task<bool> IsTheNumOfParagraphOK(Guid articleId,int num);
    }
}
