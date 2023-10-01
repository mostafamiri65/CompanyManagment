using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ForouzanTask.DataLayer.Entities.CompanyClass
{
    public class TbOurService : BaseEntity
    {
        public TbOurService()
        {

        }
        [MaxLength(500)]
        public string? Title { get; set; }
        [MaxLength(50)]
        public string? ServiceMainIcon { get; set; }
        [MaxLength(5000)]
        public string? ServiceDescription { get; set; }
        [MaxLength(50)]
        public string? servicePicture { get; set; }
    }
}
