using System;

namespace TaskManagement.Application.DTOs;

/// <summary>
/// DTO for assigning a task to a user.
/// </summary>
public class AssignTaskDto
{
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
}
