using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly List<TaskEntity> _tasks = new();

    public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
    {
        return await Task.FromResult(_tasks);
    }

    public async Task<TaskEntity?> GetTaskByIdAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        return await Task.FromResult(task);
    }

    public async Task<IEnumerable<TaskEntity>> GetTasksByUserAsync(Guid userId)
    {
        var tasks = _tasks.Where(t => t.AssignedUserId == userId).ToList();
        return await Task.FromResult(tasks);
    }

    public async Task AddTaskAsync(TaskEntity task)
    {
        _tasks.Add(task);
        await Task.CompletedTask;
    }

    public async Task UpdateTaskAsync(TaskEntity task)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask != null)
        {
            _tasks.Remove(existingTask);
            _tasks.Add(task);
        }
        await Task.CompletedTask;
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
        }
        await Task.CompletedTask;
    }
}
