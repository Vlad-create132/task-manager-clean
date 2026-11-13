using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public IEnumerable<TaskItem> GetAllTasks()
    {
        return _taskRepository.GetAllTasks();
    }

    public void CreateTask(string title, string description)
    {
        var task = new TaskItem
        {
            Title = title,
            Description = description
        };
        _taskRepository.AddTask(task);
    }

    public void MarkTaskAsCompleted(int id)
    {
        _taskRepository.CompleteTask(id);
    }
}