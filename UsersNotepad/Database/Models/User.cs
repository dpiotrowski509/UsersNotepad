using System.ComponentModel.DataAnnotations;

namespace UsersNotepad.Database.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Sex { get; set; }
        public virtual ICollection<UserAttribute> Attributes { get; set; }


    }
}
