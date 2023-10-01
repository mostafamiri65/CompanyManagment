namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class AddRolesDto
    {
        public Guid ProjectId { get; set; }
        public string? RoleTitle { get; set; }
        public bool HasAccessForView { get; set; }
        public bool HasAccessForEdit { get; set; }
        public bool HasAccessForDelete { get; set; }
    }
}
