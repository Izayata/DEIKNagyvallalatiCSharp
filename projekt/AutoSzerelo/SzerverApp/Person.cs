using System.ComponentModel.DataAnnotations;

namespace SzerverApp
{
    public class Person
    {
        /// Validáció
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }
    }
}
