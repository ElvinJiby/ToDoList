using System.Text.Json.Serialization;

namespace IntroToC_
{
    public class Task(int id, string name, string description)
    {
        public int Id { get; private set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public bool IsCompleted { get; set; } = false;

        public void MarkCompleted() {
            if (IsCompleted == false) IsCompleted = true;
        }
    }
}
