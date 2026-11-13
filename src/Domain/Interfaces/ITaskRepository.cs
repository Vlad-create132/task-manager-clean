using Domain.Entities;

namespace Domain.Interfaces;

public interface ITaskRepository
{
    IEnumerable<TaskItem> GetAllTasks();
    TaskItem? GetTaskById(int id);
    void AddTask(TaskItem task);
    void CompleteTask(int id);
}