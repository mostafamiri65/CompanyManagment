using ForouzanTask.Application.DTOs.Article;
using ForouzanTask.Application.DTOs.User;

namespace ForouzanTask.Application.Services.Interfaces
{
    public interface IHomeService
    {
        Task<List<ArticleListDto>> GetArticleList();
       
    }
}
