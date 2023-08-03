using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Todo.Core.Models
{
    public class DirectoryModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string Module { get; set; }
    }
}
