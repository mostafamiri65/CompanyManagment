using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Guid? CreateUserId { get; set; }
        [MaxLength(30)]
        public string? LastModifiedUserIp { get; set; }
        [MaxLength(30)]
        public string? LastModifiedUserMac { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
