using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jTask.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }
}
