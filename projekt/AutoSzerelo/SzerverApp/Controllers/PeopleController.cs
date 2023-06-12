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
    }
}
