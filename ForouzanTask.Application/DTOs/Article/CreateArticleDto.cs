using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.Article
{
    public class CreateArticleDto
    {
        public IFormFile? MainImage { get; set; }
        [MaxLength(500)]
        public string? Title { get; set; }
        [MaxLength(2000)]
        public string? ShortDescription { get; set; }
        [MaxLength(500)]
        public string? MetaDescription { get; set; }
        public IFormFile? SliderPicture { get; set; }

        public Guid CategoryId { get; set; }

    }
}
