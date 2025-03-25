namespace IntroToC_
{
    public class ToDoList
    {
        private List<Task> tasks;
        private int size;

        public ToDoList()
        {
            tasks = new List<Task>();
            size = 0;
        }

        public void addTask(string name, string description)
        {
            Task task = new Task(size + 1, name, description);
            if (tasks.Contains(task))
            {
                Console.WriteLine("Task already exists");
                Thread.Sleep(3000);
                return;
            }
            tasks.Add(task);
            size++;
        }
        public void removeTask(int id)
        {
            if (id > size || id < 1)
            {
                Console.WriteLine("Invalid task id.");
                Thread.Sleep(3000);
                return;
            }
            tasks.RemoveAt(id - 1);
            size--;
        }
        public void updateTask(int id, string name, string description)
        {
            if (id > size || id < 1)
            {
                Console.WriteLine("Invalid task id.");
                Thread.Sleep(3000);
                return;
            }
            tasks[id - 1].name = name;
            tasks[id - 1].description = description;
        }

        public void markTaskCompleted(int id)
        {
            if (id > size || id < 1)
            {
                Console.WriteLine("Invalid task id.");
                Thread.Sleep(3000);
                return;
            }
            tasks[id - 1].markCompleted();
        }
        public void clearList()
        {
            tasks.Clear();
            size = 0;
        }
        public bool isEmpty() { return size == 0; }
        public List<Task> GetTasks() { return tasks; }
        public int getSize() { return size; }
    }
}