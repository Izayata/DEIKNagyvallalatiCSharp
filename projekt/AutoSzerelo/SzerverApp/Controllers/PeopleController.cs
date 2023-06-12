using Microsoft.AspNetCore.Mvc;

namespace SzerverApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        //Dependency Injection Konstruktorral megoldva
        private readonly IPersonRepository _personRepository;
        public PeopleController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        //

        ///VÉGPONTOK DEFINIÁLÁSA
        //GET METÓDUS - GetAll()
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        { 
            var people = _personRepository.GetAll();

            return Ok(people);
        }

        //GET METÓDUS - GetSinglePerson
        [HttpGet("{id}")]
        public ActionResult<Person> GetSinglePerson(int id)
        { 
            var person = _personRepository.Get(id);
            if (person is null)
            {
                return NotFound();
            }
            
            return Ok(person);
        }








    }
}
