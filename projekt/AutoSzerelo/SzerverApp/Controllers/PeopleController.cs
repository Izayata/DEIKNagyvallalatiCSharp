﻿using Microsoft.AspNetCore.Mvc;

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

        ///ENDPONTOK DEFINIÁLÁSA
        //GET METÓDUS
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        { 
            var people = _personRepository.GetAll();

            return Ok(people);
        }








    }
}
