using Npgsql.TypeHandlers.DateTimeHandlers;
using NpgsqlTypes;
using System;

namespace FS.Todo.Api.Models{
    public class CreateDirectoryModel{
        public string Name{ get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string Module { get; set; }

    }
}
