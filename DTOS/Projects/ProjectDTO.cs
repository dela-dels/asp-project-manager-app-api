using System;
using System.Collections.Generic;
using ProjectManagerApp.Models;

namespace ProjectManagerApp.DTOS.Projects
{
    public class ProjectDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCompleted { get; set; }

        public List<Sprint> Sprint { get; set; }
    }
}
