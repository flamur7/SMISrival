using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public String Branch { get; set; }

        [Required]
        public String Subject { get; set; }
        [Required]
        public String TeacherCode { get; set; }

        public String University { get; set; }

        public String Title { get; set; }
    }
}
