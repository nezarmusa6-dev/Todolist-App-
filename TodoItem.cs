using System.Text.Json;
using System.IO;

namespace TodoList;

public class Todoitem
{

    
    //UNDERSTAND THE JSON STRUCTHURE 




    public List<TodoTask> Tasks = new List<TodoTask>();
    //First step
    private string filePath = "tasks.json";



    public Todoitem()
    {
        LoadTasks();
    }
    public void AddTask()
    {
        Console.WriteLine("Enter task description: ");
        string? body = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(body))
        {
            // Create a new TodoTask object and add it to the list
            TodoTask newTask = new TodoTask(body);
            Tasks.Add(newTask);
            Console.WriteLine("Task Added successfully\n");
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Task cannot be empty!\n");
        }
    }

    public void ViewTasks()
    {
        if (Tasks.Count == 0)
        {
            Console.WriteLine("Your task list is empty.\n");
            return;
        }

        Console.WriteLine("\n--- Your Tasks ---");
        for (int i = 0; i < Tasks.Count; i++)
        {
            // Check the status of THIS specific task in the list
            string checkbox = Tasks[i].IsCompleted ? "[x]" : "[ ]";
            int taskNumber = i + 1;

            Console.WriteLine($"{checkbox} {taskNumber}. {Tasks[i].Title}");
        }
        Console.WriteLine("------------------\n");
    }

    public void RemoveTask()
    {
        Console.WriteLine("Enter the task number you want to delete: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int taskNumber) && taskNumber >= 1 && taskNumber <= Tasks.Count)
        {
            int index = taskNumber - 1; // Convert 1-based number to 0-based list index
            Tasks.RemoveAt(index);
            Console.WriteLine("Task Deleted successfully\n");
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Please choose a valid task number!\n");
        }
    }

    public void MarkTaskAsCompleted()
    {
        Console.WriteLine("Enter the task number you finished: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int taskNumber) && taskNumber >= 1 && taskNumber <= Tasks.Count)
        {
            int index = taskNumber - 1;


            Tasks[index].IsCompleted = true;
            Console.WriteLine($"Task #{taskNumber} \"{Tasks[index].Title}\" marked as completed!\n");
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Please choose a valid task number!\n");
        }
    }

    public void SaveTasks()
    {
        string json = JsonSerializer.Serialize(Tasks);
        File.WriteAllText(filePath, json);
    }

    public void LoadTasks()
    {
        if (!File.Exists(filePath))
        {
            return;
        }
        string json = File.ReadAllText(filePath);

        Tasks = JsonSerializer.Deserialize<List<TodoTask>>(json) ?? new List<TodoTask>();
    }


}
