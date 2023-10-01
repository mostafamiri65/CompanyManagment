using ForouzanTask.DataLayer.Entities.Common;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class ProjectListDto
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? Title { get; set; }
        public string? ProjectTypeName { get; set; }
        public string? Description { get; set; }
        public string? TrackingCode { get; set; }
        public bool IsApproved { get; set; }
        public string? RequesterName { get; set; }       
        public string? RequesterMobile { get; set; }  
        public string? RequesterDescription { get; set; }
        public TbUser? ResponsibleUser { get; set; }
        public List<TbUser>? ResponsUsers { get; set; }

    }
}
