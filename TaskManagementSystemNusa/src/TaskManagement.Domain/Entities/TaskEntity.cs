using TaskManagement.Domain.Enums;
namespace TaskManagement.Domain.Entities;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public TaskPriorityMng Priority { get; set; }
    public TaskStatusMng Status { get; set; }
    public Guid? AssignedUserId { get; set; }
}
