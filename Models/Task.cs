using System;
namespace ProjectManagerApp.Models
{
    public class Task
    {
        public Task()
        {
        }

        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCompleted { get; set; }



        //public int SprintId { get; set; }

        public Sprint Sprint { get; set; }
    }
}
