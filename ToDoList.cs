using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntroToC_
{
    public class Task
    {
        private int id;
        private string name;
        private string description;
        private bool isCompleted = false;

        public Task(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public void markCompleted() {
            if (isCompleted == false) isCompleted = true;
        }

        public int getId() { return id; }
        public string getName() { return name; }
        public string getDescription() { return description; }
        public bool getIsCompleted() { return isCompleted; }

        public void setName(string name) { this.name = name; }
        public void setDescription(string description) { this.description = description; }
    }
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
            Task task = new Task(size+1, name, description);
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
            tasks[id - 1].setName(name);
            tasks[id - 1].setDescription(description);
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

    class Program
    {
        static void Main(String[] args)
        {
            ToDoList list = new ToDoList();
            bool exit = false;

            while (!exit)
            {
                displayList(list);
                Console.WriteLine("__________________________________________________\n");
                exit = printPrompt(list);
                Console.Clear();
            }
        }
        public static void displayList(ToDoList list)
        {
            if (list.isEmpty())
            {
                Console.WriteLine("No tasks in the list. Try adding some!");
                return;
            }

            Console.WriteLine("Tasks in the list:");
            foreach (var item in list.GetTasks())
            {
                Console.WriteLine(item.getId() + ". " + item.getName());
                Console.WriteLine("\t" + item.getDescription());
                if (item.getIsCompleted()) Console.WriteLine("\tCompleted");
                else Console.WriteLine("\tNot completed\n");
            }
        }

        public static bool printPrompt(ToDoList list)
        {
            Console.WriteLine("1. Add new task");
            Console.WriteLine("2. Remove a task");
            Console.WriteLine("3. Update a task");
            Console.WriteLine("4. Mark a task as completed");
            Console.WriteLine("5. Clear list");
            Console.WriteLine("6. Exit");

            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());

            while (choice < 1 || choice > 6)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                choice = Convert.ToInt32(Console.ReadLine());
            }

            switch (choice)
            {
                case 1: addTaskPrompt(list); break;
                case 2: removeTaskPrompt(list); break;
                case 3: updateTaskPrompt(list); break;
                case 4: markTaskCompletedPrompt(list); break;
                case 5: list.clearList(); break;
                case 6: return true;
            }
            return false;
        }

        public static void addTaskPrompt(ToDoList list)
        {
            Console.WriteLine("Enter task name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter task description:");
            string description = Console.ReadLine();
            list.addTask(name, description);
        }

        public static void removeTaskPrompt(ToDoList list)
        {
            Console.WriteLine("Enter task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            list.removeTask(id);
        }

        public static void updateTaskPrompt(ToDoList list)
        {
            Console.WriteLine("Enter task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new task name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new task description:");
            string description = Console.ReadLine();
            list.updateTask(id, name, description);
        }

        public static void markTaskCompletedPrompt(ToDoList list)
        {
            Console.WriteLine("Enter task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            list.markTaskCompleted(id);
        }
    }
}
