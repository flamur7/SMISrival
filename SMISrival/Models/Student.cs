using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Models
{
    public class Student : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String ParentName { get; set; }
        [Required]
        public String Surname { get; set; }
        public char Gender { get; set; }
        [Required] 
        public String Branch { get; set; }
        [Required]
        public String PersonalId { get; set; }
        public int Semester { get; set; }

    }
} 