using Microsoft.Extensions.Logging;
using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.Application.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly ILogger<TaskService> _logger;

    public TaskService(ITaskRepository taskRepository, ILogger<TaskService> logger)
    {
        _taskRepository = taskRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
    {
        _logger.LogInformation("Fetching all tasks...");
        return await _taskRepository.GetAllTasksAsync();
    }

    public async Task<TaskEntity?> GetTaskByIdAsync(Guid id)
    {
        _logger.LogInformation("Fetching task with ID: {TaskId}", id);
        var task = await _taskRepository.GetTaskByIdAsync(id);

        if (task == null)
        {
            _logger.LogWarning("Task with ID {TaskId} not found", id);
        }

        return task;
    }

    public async Task AddTaskAsync(CreateTaskDto dto)
    {
        _logger.LogInformation("Adding a new task: {Title}", dto.Title);

        var task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Priority = (TaskPriorityMng)dto.Priority,
            Status = TaskStatusMng.Pending
        };

        await _taskRepository.AddTaskAsync(task);
        _logger.LogInformation("Task {TaskId} created successfully", task.Id);
    }

    public async Task UpdateTaskAsync(Guid id, UpdateTaskDto dto)
    {
        _logger.LogInformation("Updating task {TaskId}", id);
        var task = await _taskRepository.GetTaskByIdAsync(id);

        if (task == null)
        {
            _logger.LogError("Task {TaskId} not found", id);
            throw new Exception("Task not found");
        }

        task.Title = dto.Title ?? task.Title;
        task.Description = dto.Description ?? task.Description;
        task.DueDate = dto.DueDate ?? task.DueDate;
        task.Priority = dto.Priority.HasValue ? (TaskPriorityMng)dto.Priority : task.Priority;
        task.Status = dto.Status.HasValue ? (TaskStatusMng)dto.Status : task.Status;

        await _taskRepository.UpdateTaskAsync(task);
        _logger.LogInformation("Task {TaskId} updated successfully", id);
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        _logger.LogInformation("Deleting task {TaskId}", id);
        await _taskRepository.DeleteTaskAsync(id);
        _logger.LogInformation("Task {TaskId} deleted successfully", id);
    }
}
