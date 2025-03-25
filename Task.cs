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
        private int Id { get; } = id;
        private string Name { get; set; } = name;
        private string Description { get; set; } = description;
        private bool IsCompleted { get; set; } = false;

        public void markCompleted() {
            if (IsCompleted == false) IsCompleted = true;
        }
    }
}
