using ForouzanTask.DataLayer.Entities.Article;
using ForouzanTask.DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.Article
{
    public class ArticleListDto
    {
     
        public Guid Id { get; set; }
        public TbCategory? Category { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(50)]
        public string? MainImageName { get; set; }
        [MaxLength(500)]
        public string? Title { get; set; }
        [MaxLength(2000)]
        public string? ShortDescription { get; set; }
        [MaxLength(500)]
        public string? MetaDescription { get; set; }
        public bool IsApproal { get; set; } 
        [MaxLength(50)]
        public string? SliderPicture { get; set; }
        public bool IsShown { get; set; } 
        public TbUser? CreatedBy { get; set; }

    }
}
