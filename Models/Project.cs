using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagerApp.Models
{
    public class Project
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "The start date field is required")]
        [Display(Name = "start_date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The end date field is required")]
        [Display(Name = "end_date")]
        public DateTime EndDate { get; set; }

        public bool IsCompleted { get; set; }

        public List<Sprint> Sprint { get; set; }
    }
}
