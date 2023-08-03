using System;

namespace FS.Todo.Data.Entities
{
    public class Status
{
        public string Pending { get; set; }
        public string Indevelopment { get; set; }
        public string Testing { get; set; }
        public string Closed { get; set; }
        public int Classification { get; set; }
        public string Analytics { get; set; }
        public string Model  { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
