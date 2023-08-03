using System;

namespace FS.Todo.Data.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string System { get; set; }
        public string Module { get; set; }
        public int Priority { get; set; }
        public bool IsResponsible { get; set; }
        public string Requesttype { get; set; }
        public int Date { get; set; }
        public string Request { get; set; }

    }
}