using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerApp.Models
{
    public class Sprint
    {
        public Sprint()
        {
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCompleted { get; set; }

        public long ProjectId { get; set; }



        [ForeignKey("ProjectId")]
        public Project Project { get; set; }


        public List<Task> Task { get; set; }
    }
}
