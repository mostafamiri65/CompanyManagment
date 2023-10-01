using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ForouzanTask.Application.DTOs.Article
{
    public class CreateSubArticleDto
    {
        [MaxLength(5000)]
        public string? Content { get; set; }
        public int NumberOfParagraph { get; set; }
        [MaxLength(50)]
        public IFormFile? Picture { get; set; }
        public Guid ArticleId { get; set; }

    }
}
