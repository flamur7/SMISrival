using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Models
{
    public class CreateGrade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String PersonalId { get; set; }
        [Required]
        public String CodeTeacher { get; set; }
        [Required]
        public String Subjects { get; set; }
        [Required]
        public String Grade { get; set; }
    }
}
