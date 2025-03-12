using Microsoft.Extensions.Logging;
using Moq;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Repositories;
using Xunit;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _taskRepositoryMock;
    private readonly Mock<ILogger<TaskService>> _loggerMock; 
    private readonly TaskService _taskService;

    public TaskServiceTests()
    {
        _taskRepositoryMock = new Mock<ITaskRepository>();
        _loggerMock = new Mock<ILogger<TaskService>>(); 
        _taskService = new TaskService(_taskRepositoryMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task AddTaskAsync_ShouldAddTask()
    {
        var priorityValue = 1;
        if (Enum.TryParse(priorityValue.ToString(), out TaskPriorityMng parsedPriority))
        {
            var createTaskDto = new CreateTaskDto
            {
                Title = "Test Task",
                Description = "Test Description",
                DueDate = DateTime.UtcNow.AddDays(1),
                Priority = parsedPriority
            };
            
            await _taskService.AddTaskAsync(createTaskDto);

            _taskRepositoryMock.Verify(repo => repo.AddTaskAsync(It.IsAny<TaskEntity>()), Times.Once);
        }
        else
        {
            throw new ArgumentException("Invalid priority value.");
        }
    }

    [Fact]
    public async Task GetTaskByIdAsync_ShouldReturnTask_IfExists()
    {
        var taskId = Guid.NewGuid();
        var task = new TaskEntity { Id = taskId, Title = "Sample Task" };

        _taskRepositoryMock.Setup(repo => repo.GetTaskByIdAsync(taskId))
            .ReturnsAsync(task);

        var result = await _taskService.GetTaskByIdAsync(taskId);

        Assert.NotNull(result);
        Assert.Equal(taskId, result.Id);
    }
}
