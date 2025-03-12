using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Repositories;
public interface ITaskRepository
{
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task<TaskEntity?> GetTaskByIdAsync(Guid id);
    Task<IEnumerable<TaskEntity>> GetTasksByUserAsync(Guid userId);
    Task AddTaskAsync(TaskEntity task);
    Task UpdateTaskAsync(TaskEntity task);
    Task DeleteTaskAsync(Guid id);
}
