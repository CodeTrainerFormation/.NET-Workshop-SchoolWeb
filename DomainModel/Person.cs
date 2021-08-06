using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    //[Table("Persons")]
    public abstract class Person
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Un prénom est obligatoire !")]
        [StringLength(50)]
        //[Column("PRENOM")]
        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(70)]
        [DisplayName("Nom")]
        public string LastName { get; set; }

        [Range(0, 140)]
        public int Age { get; set; }
    }
}
