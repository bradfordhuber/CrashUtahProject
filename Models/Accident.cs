using System;
using System.ComponentModel.DataAnnotations;
namespace CrashUtahProject.Models
{
    public class Accident
    {
        [Required]
        [Key]
        public string crash_id { get; set; }
        public string city { get; set; }
        public string county_name { get; set; }
        public string crash_severity_id { get; set; }
    }
}