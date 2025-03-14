using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToC_
{
    public class Task
    {
        private int id;
        private string name;
        private string description;
        private bool isCompleted;

        public Task(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.isCompleted = false;
        }

        public void markCompleted() {
            if (isCompleted == false) isCompleted = true;
        }

        public int getId() { return id; }
        public string getName() { return name; }
        public string getDescription() { return description; }

        public void setName(string name) { this.name = name; }
        public void setDescription(string description) { this.description = description; }
    }
    public class ToDoList
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("test");
        }
    }
}
