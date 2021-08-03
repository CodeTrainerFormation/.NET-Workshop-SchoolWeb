using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Teachers")]
    public class Teacher : Person
    {
        [StringLength(30)]
        [Required]
        public string Discipline { get; set; }
        public DateTime HiringDate { get; set; }

        // propriété de navigation
        //[ForeignKey(nameof(Classroom))]
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
