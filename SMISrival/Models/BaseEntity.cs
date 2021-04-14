using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Models
{
    public class BaseEntity
    {
        [DisplayName("Created By")]

        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
