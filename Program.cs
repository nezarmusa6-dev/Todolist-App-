namespace TodoList;

class Program
{
    static void Main(string[] args)
    {

        Todoitem task = new Todoitem();

        while (true)
        {
            Console.WriteLine("""
        1. Veiw all tasks 
        2. Add a new task 
        3. Mark task as completed
        4. Delete a task
        5. Exit
        """);
            string? userChoice = Console.ReadLine();
            bool isSucccess = int.TryParse(userChoice, out int userChoiceINT);
            // Console.Write(userChoice + " " + userChoiceINT.GetType());
            if (isSucccess && userChoiceINT >= 1 && userChoiceINT <= 5)
            {
                    if (userChoiceINT == 1)
                    {
                        task.ViewTasks();
                    }
                    else if (userChoiceINT == 2)
                    {
                        task.AddTask();
                    }
                    else if (userChoiceINT == 3)
                    {
                        task.MarkTaskAsCompleted();
                    }
                    else if (userChoiceINT == 4)
                    {
                        task.RemoveTask();
                    }
                    else if (userChoiceINT == 5)
                    {
                        break;
                    }
                }
            else
            {
                Console.WriteLine("Please Enter a valid input!!");
            }
        }

        




    }
}


