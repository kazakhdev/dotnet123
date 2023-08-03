using System;


namespace FS.Todo.Core.Models
{
    public class DirectoryModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid Id { get; set; }
        public string Module { get; set; }
    }
}
