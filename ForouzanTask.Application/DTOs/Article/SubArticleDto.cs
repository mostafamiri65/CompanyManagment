using ForouzanTask.DataLayer.Entities.Article;
using System.ComponentModel.DataAnnotations;

namespace ForouzanTask.Application.DTOs.Article
{
    public class SubArticleDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public int NumberOfParagraph { get; set; }
        public string? PictureName { get; set; }
        public ArticleDto? Article { get; set; }
    }
}
