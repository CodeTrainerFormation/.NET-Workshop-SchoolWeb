using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Administrative")]
    public class Administrative : Person
    {
        [StringLength(15)]
        public string Activity { get; set; }

        public int Salary { get; set; }
    }
}
