using System;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.DTOs;

/// <summary>
/// DTO for creating a new task.
/// </summary>
public class CreateTaskDto
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskPriorityMng Priority { get; set; }
}
