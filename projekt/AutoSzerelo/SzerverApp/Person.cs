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
        [Range(typeof(DateTime), "1990-01-01", "2000-01-01")]
        public DateTime? BirthDate { get; set; }
    }
}
