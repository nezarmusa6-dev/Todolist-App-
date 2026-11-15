namespace TodoList;

    public class TodoTask
    {
        
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    
        
        public TodoTask() { }

       
        public TodoTask(string title)
        {
            Title = title;
            IsCompleted = false;
        }
    }