namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class AddTaskDto
    {
        public Guid RoleId { get; set; }
        public Guid ProjectId { get; set; }
        public bool IsUsedDefaults { get; set; }
        public Guid? ProjectTaskTitleId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? DoingUserId { get; set; }
        public int NumberOfDaysHasTime { get; set; }
        public string? RequestedTitles { get; set; }
    }
}
