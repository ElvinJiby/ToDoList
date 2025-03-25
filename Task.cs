using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
