using System;


namespace Systematics.Task.Web.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Progress { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
