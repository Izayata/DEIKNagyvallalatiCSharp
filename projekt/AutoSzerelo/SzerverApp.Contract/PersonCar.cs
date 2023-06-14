using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SzerverApp.Contract
{
    public class PersonCar
    {
        /// Validáció
        [Key] //Elsődleges kulcs beállítása
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //automatikus kulcs generálás
        public int Id { get; set; }
        //public int DuplicatedId { get; set; }


        ///PERSON DATAS
        [Required]
        //[MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Must be a valid email adress!")]
        public string Email { get; set; }


        ///AUTOA DATAS
        //márka -> toyota
        [Required]
        public string Brand { get; set; }

        [Required]
        //típus -> corolla
        public string Type { get; set; }
        //évjárat -> pl 2000 (2023 esetén ez 23 éves)
        [Required]
        //[Range(typeof(DateTime), "1990-01-01", "2000-01-01")]
        public DateTime? ProductionYear { get; set; } //A ? miatt nullable lesz ez a field (nem kötelező kitölteni), a [Required] annotáció felülírja a ?-ecskét

        /*
        //Item osztály hozzákapcsolása az osztályhoz
        public virtual ICollection<Item> Items { get; set; }
        */
    }
}
