using Microsoft.AspNetCore.Mvc;

namespace SzerverApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        //Dependency Injection Konstruktorral megoldva
        private readonly IPersonRepository _personRepository;
        private readonly ILogger<PeopleController> _logger;
        public PeopleController(IPersonRepository personRepository, ILogger<PeopleController> logger)
        {
            _personRepository = personRepository;
            _logger = logger;
        }
        //

        ///VÉGPONTOK DEFINIÁLÁSA
        //GET METÓDUS - GetAll()
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            _logger.LogInformation("People endpoint 'GetAll' was called");
            var people = _personRepository.GetAll();

            return Ok(people);
        }

        //GET METÓDUS - GetSinglePerson(int id)
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


        //ADD METÓDUS - Post()
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var existingPerson = _personRepository.Get(person.Id);
            if (existingPerson is not null)
            { 
                return Conflict();
            }

            _personRepository.Upsert(person);
            return Ok();
        }

        //UPDATE METÓDUS - Put()
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            if (id != person.Id)
            { 
                return BadRequest();
            }

            var existingPerson = _personRepository.Get(id);
            if (existingPerson is null)
            { 
                return NotFound();
            }


            _personRepository.Upsert(person);
            
            return NoContent(); //lehet Ok() is, általában a delete esetén használják

        }

        //DELETE METÓDUS - Delete()
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPerson = _personRepository.Get(id);
            if (existingPerson is null)
            {
                return NotFound();
            }


            _personRepository.Delete(id);
            
            return NoContent();
        }


        ///MŰKÖDNEK A VÉGPONTOK! :)



    }
}
