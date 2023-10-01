using System.ComponentModel.DataAnnotations;

namespace ForouzanTask.DataLayer.Entities.Article
{
    public class TbCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public virtual List<TbArticle>? TbArticles { get; set; }
    }
}
