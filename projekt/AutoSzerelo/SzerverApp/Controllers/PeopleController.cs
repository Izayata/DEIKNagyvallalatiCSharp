using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SzerverApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        //Dependency Injection Konstruktorral megoldva
        private readonly DemoContext _demoContext;
        //private readonly IPersonRepository _personRepository;
        private readonly ILogger<PeopleController> _logger;
        public PeopleController(DemoContext demoContext, ILogger<PeopleController> logger)
        {
            _demoContext = demoContext;
            //_personRepository = personRepository;
            _logger = logger;
        }
        //

        ///VÉGPONTOK DEFINIÁLÁSA
        //GET METÓDUS - GetAll()
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            _logger.LogInformation("People endpoint 'GetAll' was called");
            //var people = _personRepository.GetAll();
            var people = await _demoContext.People.ToListAsync();

            return Ok(people);
        }

        //GET METÓDUS - GetSinglePerson(int id)
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetSinglePerson(int id)
        {
            //var person = _personRepository.Get(id);
            var person = await _demoContext.People.FindAsync(id);
            if (person is null)
            {
                return NotFound();
            }
            
            return Ok(person);
        }

        /*
        //GET METÓDUS - GetItems(int id)
        [HttpGet("{id}/items")]
        public async Task<ActionResult<Person>> GetItems(int id)
        {
            //var person = _personRepository.Get(id);
            var person = await _demoContext.People.FindAsync(id);
            if (person is null)
            {
                return NotFound();
            }

            return Ok(person.Items);
        }
        */




        //ADD METÓDUS - Post()
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            _demoContext.People.Add(person);
            await _demoContext.SaveChangesAsync();

            return Ok();
        }

        //UPDATE METÓDUS - Put()
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person person)
        {
            if (id != person.Id)
            { 
                return BadRequest();
            }

            var existingPerson = await _demoContext.People.FindAsync(id);
            if (existingPerson is null)
            { 
                return NotFound();
            }


            existingPerson.Name = person.Name;
            existingPerson.Email = person.Email;
            existingPerson.BirthDate = person.BirthDate;
            _demoContext.SaveChangesAsync();
            
            return NoContent(); //lehet Ok() is, általában a delete esetén használják

        }

        //DELETE METÓDUS - Delete()
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var existingPerson = _personRepository.Get(id);
            var existingPerson = await _demoContext.People.FindAsync(id);
            if (existingPerson is null)
            {
                return NotFound();
            }


            //_personRepository.Delete(id);
            _demoContext.People.Remove(existingPerson);
            await _demoContext.SaveChangesAsync(); //Ez a metódus frissíti az adatbázist
            //érdemes try-catch segítségével kivételkezelést végezni a végleges produkcióhoz
            
            return NoContent();
        }


        ///MŰKÖDNEK A VÉGPONTOK! :)



    }
}
