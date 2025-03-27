using System.Text.Json;

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
                Console.Clear();
                DisplayList(list);
                Console.WriteLine("__________________________________________________\n");
                exit = PrintPrompt(ref list);
            }
        }

        // Utility
        public static void DisplayList(ToDoList list)
        {
            if (list.IsEmpty())
            {
                Console.WriteLine("\nNo tasks in the list. Try adding some!");
                return;
            }

            Console.WriteLine("\nTasks in the list:");
            foreach (var item in list.Tasks)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
                Console.WriteLine("\t" + item.Description);
                Console.Write("\tStatus: ");
                if (item.IsCompleted) Console.WriteLine("Completed");
                else Console.WriteLine("Not completed\n");
            }
        }

        public static bool PrintPrompt(ref ToDoList list)
        {
            Console.WriteLine("1. Add new task");
            Console.WriteLine("2. Remove a task");
            Console.WriteLine("3. Update a task");
            Console.WriteLine("4. Mark a task as completed");
            Console.WriteLine("5. Clear list");
            Console.WriteLine("6. Load task list from a file");
            Console.WriteLine("7. Save task list to a file");
            Console.WriteLine("8. Exit\n");

            int choice = GetValidIntInput("Enter your choice: ");

            while (choice < 1 || choice > 8)
            {
                choice = GetValidIntInput("Invalid choice. Please try again.");
            }

            switch (choice)
            {
                case 1: AddTaskPrompt(list); break;
                case 2: RemoveTaskPrompt(list); break;
                case 3: UpdateTaskPrompt(list); break;
                case 4: MarkTaskCompletedPrompt(list); break;
                case 5: list.ClearList(); break;
                case 6: LoadListFromFile(ref list); break;
                case 7: SaveListToFile(list); break;
                case 8: return true;
            }
            return false;
        }

        public static void AddTaskPrompt(ToDoList list)
        {
            string name = GetValidStringInput("Enter task name:");
            string description = GetValidStringInput("Enter task description:");
            list.AddTask(name, description);
        }

        public static void RemoveTaskPrompt(ToDoList list)
        {
            try { list.RemoveTask(GetValidIntInput("Enter task id:")); }
            catch (Exception e) { Console.WriteLine($"{e.Message}"); }
        }

        public static void UpdateTaskPrompt(ToDoList list)
        {
            int id = GetValidIntInput("Enter task id:");
            string name = GetValidStringInput("Enter new task name:");
            string description = GetValidStringInput("Enter new task description:");
            try { list.UpdateTask(id, name, description); }
            catch (Exception e) { Console.WriteLine($"{e.Message}"); }
        }

        public static void MarkTaskCompletedPrompt(ToDoList list)
        {
            try { list.MarkTaskCompleted(GetValidIntInput("Enter task id:")); }
            catch (Exception e) { Console.WriteLine($"{e.Message}"); }
        }

        public static void LoadListFromFile(ref ToDoList list)
        {
            string filePath = GetValidStringInput("Enter the path of the Json file (with .json):");
            if (!filePath.Contains(".json"))
            {
                ToDoList.PrintMSG("Invalid file path. File must have a .json file extension.");
            }
            if (!File.Exists(filePath))
            {
                ToDoList.PrintMSG("File not found."); 
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);
                ToDoList? newlist = JsonSerializer.Deserialize<ToDoList>(jsonString);
                if (newlist == null)
                {
                    ToDoList.PrintMSG("Error: Unable to deserialise Json file.");
                    return;
                }

                list = newlist;
                ToDoList.PrintMSG($"List loaded successfully from: {filePath}");
            }
            catch (Exception e)
            {
                ToDoList.PrintMSG($"Error while parsing: {e.Message}");
            }
        }

        public static void SaveListToFile(ToDoList list)
        {
            if (list.Size == 0)
            {
                ToDoList.PrintMSG("Cannot save an empty list.");
                return;
            }
            string fileName = GetValidStringInput("Enter a name for the file (without .json):");
            string filePath = $"{fileName}.json";

            try
            {
                string jsonString = JsonSerializer.Serialize(list);
                File.WriteAllText(filePath, jsonString);
                
                ToDoList.PrintMSG($"File saved at: {filePath}");
            }
            catch (Exception e)
            {
                ToDoList.PrintMSG($"Error: {e.Message}");
            }

        }

        // Input validation
        public static int GetValidIntInput(string prompt)
        {
            int result;
            Console.WriteLine(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            return result;
        }

        public static string GetValidStringInput(string prompt)
        {
            string? result;
            Console.WriteLine(prompt);
            while (true)
            {
                result = Console.ReadLine();
                if (!string.IsNullOrEmpty(result)) break;
                else Console.WriteLine("Input cannot be empty. Please enter a non-empty string.");
            }
            return result;
        }
    }
}