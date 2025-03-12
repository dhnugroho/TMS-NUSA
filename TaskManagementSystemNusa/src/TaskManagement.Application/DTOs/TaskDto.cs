using System;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.DTOs;

/// <summary>
/// DTO for returning task details.
/// </summary>
public class TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskPriorityMng Priority { get; set; }
    public TaskStatusMng Status { get; set; }
}
