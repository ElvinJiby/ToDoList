namespace IntroToC_
{
    class Program
    {
        public static void Main()
        {
            ToDoList list = new();
            bool exit = false;

            while (!exit)
            {
                DisplayList(list);
                Console.WriteLine("__________________________________________________\n");
                exit = PrintPrompt(list);
            }
        }
        public static void DisplayList(ToDoList list)
        {
            if (list.IsEmpty())
            {
                Console.WriteLine("No tasks in the list. Try adding some!");
                return;
            }

            Console.WriteLine("Tasks in the list:");
            foreach (var item in list.Tasks)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
                Console.WriteLine("\t" + item.Description);
                if (item.IsCompleted) Console.WriteLine("\tCompleted");
                else Console.WriteLine("\tNot completed\n");
            }
        }

        public static bool PrintPrompt(ToDoList list)
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
                case 1: AddTaskPrompt(list); break;
                case 2: RemoveTaskPrompt(list); break;
                case 3: UpdateTaskPrompt(list); break;
                case 4: MarkTaskCompletedPrompt(list); break;
                case 5: list.ClearList(); break;
                case 6: return true;
            }
            return false;
        }

        public static void AddTaskPrompt(ToDoList list)
        {
            Console.WriteLine("Enter task name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter task description:");
            string description = Console.ReadLine();
            list.AddTask(name, description);
        }

        public static void RemoveTaskPrompt(ToDoList list)
        {
            Console.WriteLine("Enter task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            list.RemoveTask(id);
        }

        public static void UpdateTaskPrompt(ToDoList list)
        {
            Console.WriteLine("Enter task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new task name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new task description:");
            string description = Console.ReadLine();
            list.UpdateTask(id, name, description);
        }

        public static void MarkTaskCompletedPrompt(ToDoList list)
        {
            Console.WriteLine("Enter task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            list.MarkTaskCompleted(id);
        }
    }
}