using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Classroom
    {
        // propriétés scalaires
        public int ClassroomId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Range(-1, 5)]
        public int Floor { get; set; }

        public string Corridor { get; set; }

        // propriétés de navigation
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
