using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();

    public IEnumerable<TaskItem> GetAllTasks()
    {
        return _tasks;
    }

    public TaskItem? GetTaskById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public void AddTask(TaskItem task)
    {
        task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
        _tasks.Add(task);
    }

    public void CompleteTask(int id)
    {
        var task = GetTaskById(id);
        task?.MarkAsCompleted();
    }
}