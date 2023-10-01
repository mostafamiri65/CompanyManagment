using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Article
{
    public class TbSubArticle : BaseEntity
    {
        public TbSubArticle()
        {
           
        }
        public Guid ArticleId { get; set; }
        [MaxLength(5000)]
        public string? Content { get; set; }
        public int NumberOfParagraph { get; set; }
        [MaxLength(50)]
        public string? PictureName { get; set; }
        public bool LoadPictureInMaxSize { get; set; }

        [ForeignKey("ArticleId")]
        public virtual TbArticle? TbArticle { get; set; }

    }
}
