using System;
using System.Collections.Generic;
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
            Task task = new Task(size + 1, name, description);
            if (tasks.Contains(task))
            {
                Console.WriteLine("Task already exists");
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
                return;
            }
            tasks[id - 1].markCompleted();
        }

        public int getSize() { return size; }

        public void clearList()
        {
            tasks.Clear();
            size = 0;
        }
    }
}
