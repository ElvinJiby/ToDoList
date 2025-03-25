namespace IntroToC_
{
    public class ToDoList
    {
        public List<Task> Tasks { get; set; } = new List<Task>();
        public int Size { get; private set; } = 0;

        public void AddTask(string name, string description)
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty."); return;
            }
            if (String.IsNullOrEmpty(description))
            {
                Console.WriteLine("Description cannot be empty."); return;
            }

            Task task = new(Size + 1, name, description);
            if (Tasks.Contains(task))
            {
                Console.WriteLine("Task already exists");
                Thread.Sleep(3000);
                return;
            }
            Tasks.Add(task);
            Size++;
        }
        public void RemoveTask(int id)
        {
            if (id > Size || id < 1)
            {
                Console.WriteLine("Invalid task id.");
                Thread.Sleep(3000);
                return;
            }
            Tasks.RemoveAt(id - 1);
            Size--;
        }
        public void UpdateTask(int id, string name, string description)
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty."); return;
            }
            if (String.IsNullOrEmpty(description))
            {
                Console.WriteLine("Description cannot be empty."); return;
            }
            if (id > Size || id < 1)
            {
                Console.WriteLine("Invalid task id.");
                Thread.Sleep(3000);
                return;
            }
            Tasks[id - 1].Name = name;
            Tasks[id - 1].Description = description;
        }

        public void MarkTaskCompleted(int id)
        {
            if (id > Size || id < 1)
            {
                Console.WriteLine("Invalid task id.");
                Thread.Sleep(3000);
                return;
            }
            Tasks[id - 1].MarkCompleted();
        }
        public void ClearList()
        {
            Tasks.Clear();
            Size = 0;
        }
        public bool IsEmpty() { return Size == 0; }
    }
}