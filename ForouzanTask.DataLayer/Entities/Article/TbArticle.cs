using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Article
{
    public class TbArticle : BaseEntity
    {
        public TbArticle()
        {
           
        }
        public Guid CategoryId { get; set; }

        [MaxLength(50)]
        public string? MainImageName { get; set; }
        [MaxLength(500)]
        public string? Title { get; set; }
        [MaxLength(2000)]
        public string? ShortDescription { get; set; }
        [MaxLength(500)]
        public string? MetaDescription { get; set; }
        public bool IsApproal { get; set; } = false;
        [MaxLength(50)]
        public string? SliderPicture { get; set; }
        public bool IsShown { get; set; } = true;

        public virtual List<TbSubArticle>? TbSubArticles { get; set; }

        [ForeignKey("CategoryId")]
        public virtual TbCategory? TbCategory { get; set; }

    }
}
