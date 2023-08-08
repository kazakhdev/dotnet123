using Npgsql.TypeHandlers.DateTimeHandlers;
using NpgsqlTypes;
using System;
namespace FS.Todo.Api.Models
{
    public class CreateTodoModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string System { get; set; }
        public string Module { get; set; }
        public string Priority { get; set; }
        public bool IsResponsible { get; set; }
        public string Requesttype { get; set; }
        public DateHandler Date { get; set; }
        public string RequestedPerson { get; set; }


    }
}