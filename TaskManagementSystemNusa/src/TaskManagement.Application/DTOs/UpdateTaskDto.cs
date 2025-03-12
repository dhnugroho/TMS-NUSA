using TaskManagement.Domain.Enums;
namespace TaskManagement.Application.DTOs;

/// <summary>
/// DTO for updating an existing task.
/// </summary>
public class UpdateTaskDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public TaskPriorityMng? Priority { get; set; }
    public TaskStatusMng? Status { get; set; }
}
