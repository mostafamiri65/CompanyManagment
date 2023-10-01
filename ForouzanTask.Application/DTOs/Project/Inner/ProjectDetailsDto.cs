using ForouzanTask.DataLayer.Entities.Projects;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class ProjectDetailsDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public TbProjectType? ProjectType { get; set; }
        public List<TbProjectDocument>? Documents { get; set; }
        public List<TbProjectNote>? Notes { get; set; }
        public List<TbProjectRequest>? Requesters { get; set; }
        public List<TbProjectRole>? Roles { get; set; }
        public List<TbUserInProject>? Users { get; set; }
        public List<TbProjectTask>? Tasks { get; set; }
        public List<TbProjectTaskDetails>? TaskDetails { get; set; }
        public string? Description { get; set; }
        public bool IsApproved { get; set; }
        public string? CreateDate { get; set; }
    }
}
