namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class AddNoteDto
    {
        public Guid ProjectId { get; set; }
        public string? Description { get; set; }
    }
}
