using System;

namespace FS.Todo.Api.Models
{
    public class UpdateDirectoryModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string Module { get; set; }

    }
}
