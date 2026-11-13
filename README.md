# task-manager-clean

Консольний менеджер завдань, розроблений за принципами **Clean Architecture** (Чистої архітектури), із дотриманням методології **GitFlow** та стандартів **Conventional Commits**.

---

## 🏗 Архітектура застосунку

Проєкт розділено на 4 незалежні шари відповідно до принципів Clean Architecture. Напрямок залежностей спрямований всередину до доменного ядра.

```mermaid
graph TD
    subgraph Presentation ["Presentation Layer (CLI)"]
        A[Program.cs]
    end

    subgraph Infrastructure ["Infrastructure Layer"]
        B[InMemoryTaskRepository]
    end

    subgraph Application ["Application Layer"]
        C[TaskService]
    end

    subgraph Domain ["Domain Layer (Core)"]
        D[TaskItem & ITaskRepository]
    end

    A --> C
    A --> B
    B -. реалізує .-> D
    C --> D
    Infrastructure --> Domain
    Application --> Domain

## Інструкція зі збірки і запуску

### Передумови
Для запуску проєкту у вас має бути встановлено:
- [.NET SDK](https://dotnet.microsoft.com/) (версії 6.0 або новішої).
- Git.

### Кроки для запуску:

1. **Клонуйте репозиторій:**
   ```bash
   git clone [https://github.com/Vlad-create132/task-manager-clean.git](https://github.com/Vlad-create132/task-manager-clean.git)
   cd task-manager-clean

   Зберіть проєкт:
   dotnet build
   Запустіть застосунок:
   dotnet run --project src/Presentation/CLI/Program.cs