using System.Text.Json.Serialization;

namespace IntroToC_
{
    public class Task
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public void MarkCompleted() {
            if (IsCompleted == false) IsCompleted = true;
        }

        public Task(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            IsCompleted = false;
        }

        [JsonConstructor]
        public Task(int id, string name, string description, bool isCompleted)
        {
            Id = id;
            Name = name;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}
