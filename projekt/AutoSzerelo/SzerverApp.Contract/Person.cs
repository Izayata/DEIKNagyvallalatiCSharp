using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SzerverApp.Contract
{
    public class Person
    {
        /// Validáció
        //[Key] //Elsődleges kulcs beállítása
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //automatikus kulcs generálás
        public int Id { get; set; }
        public int DuplicatedId { get; set; }

        [Required]
        //[MaxLength(25)]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Must be a valid email adress!")]
        public string Email { get; set; }

        //[Required]
        //[Range(typeof(DateTime), "1990-01-01", "2000-01-01")]
        public DateTime? BirthDate { get; set; } //A ? miatt nullable lesz ez a field (nem kötelező kitölteni), a [Required] annotáció felülírja a ?-ecskét




        /*
        //Item osztály hozzákapcsolása az osztályhoz
        public virtual ICollection<Item> Items { get; set; }
        */
    }
}
