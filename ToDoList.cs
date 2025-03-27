using System.Text.Json.Serialization;

namespace IntroToC_
{
    public class ToDoList
    {
        public List<Task> Tasks { get; set; } = [];
        public int Size { get; private set; } = 0;

        [JsonConstructor]
        public ToDoList(List<Task> tasks)
        {
            this.Tasks = tasks;
            this.Size = tasks.Count;
        }
        public ToDoList(){}

        // Task Functions
        public void AddTask(string name, string description)
        {
            Task task = new(Size + 1, name, description);
            if (Tasks.Contains(task))
            {
                PrintMSG("Task already exists");
                return;
            }
            Tasks.Add(task);
            Size++;
            PrintMSG("Task added successfully.");
        }
        public void RemoveTask(int id)
        {
            if (!IsValidId(id)) return;
            Tasks.RemoveAt(id - 1);
            Size--;
            PrintMSG("Task removed successfully.");
        }
        public void UpdateTask(int id, string name, string description)
        {
            if (!IsValidId(id)) return;
            Tasks[id - 1].Name = name;
            Tasks[id - 1].Description = description;
            PrintMSG("Task modified successfully.");
        }
        public void MarkTaskCompleted(int id)
        {
            if (!IsValidId(id)) return;
            Tasks[id - 1].MarkCompleted();
            PrintMSG("Task successfully marked as complete.");
        }

        // Utility
        public void ClearList()
        {
            Tasks.Clear();
            Size = 0;
            PrintMSG("List has been cleared successfully.");
        }
        public static void PrintMSG(string msg)
        {
            Console.WriteLine(msg);
            Thread.Sleep(3000);
        }
        public bool IsValidId(int id)
        {
            if (id > Size || id < 1)
            {
                PrintMSG("Invalid id. No task contains this id.");
                return false;
            }
            return true;
        }
        public bool IsEmpty() { return Size == 0; }
    }
}