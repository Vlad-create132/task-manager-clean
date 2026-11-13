using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Presentation.CLI;

class Program
{
    static void Main(string[] args)
    {
        // Composition Root: збираємо залежності (Dependency Injection вручну)
        ITaskRepository taskRepository = new InMemoryTaskRepository();
        TaskService taskService = new TaskService(taskRepository);

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n=== Task Manager (Clean Architecture) ===");
            Console.WriteLine("1. Показати всі завдання");
            Console.WriteLine("2. Додати нове завдання");
            Console.WriteLine("3. Позначити завдання як виконане");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть дію: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var tasks = taskService.GetAllTasks().ToList();
                    if (!tasks.Any())
                    {
                        Console.WriteLine("Список завдань порожній.");
                    }
                    else
                    {
                        foreach (var t in tasks)
                        {
                            string status = t.IsCompleted ? "[Виконано]" : "[В процесі]";
                            Console.WriteLine($"{t.Id}. {status} {t.Title} — {t.Description}");
                        }
                    }
                    break;

                case "2":
                    Console.Write("Введіть назву завдання: ");
                    string title = Console.ReadLine() ?? string.Empty;
                    Console.Write("Введіть опис завдання: ");
                    string desc = Console.ReadLine() ?? string.Empty;
                    taskService.CreateTask(title, desc);
                    Console.WriteLine("Завдання успішно додано!");
                    break;

                case "3":
                    Console.Write("Введіть ID завдання: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        taskService.MarkTaskAsCompleted(id);
                        Console.WriteLine("Статус завдання оновлено!");
                    }
                    else
                    {
                        Console.WriteLine("Некоректний ID.");
                    }
                    break;

                case "0":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                    break;
            }
        }
    }
}