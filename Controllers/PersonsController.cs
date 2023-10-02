namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Persons;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    private IPersonService _personService;
    private IMapper _mapper;

    public PersonsController(
        IPersonService personService,
        IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }

    // GET: api/Person
    [HttpGet]
    public IActionResult GetAll()
    {
        var persons = _personService.GetAll();
        return Ok(persons);
    }

    // GET: api/Person/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var person = _personService.GetById(id);
        return Ok(person);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _personService.Create(model);
        return Ok(new { message = "Person created" });
    }

    // PUT: api/Person/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _personService.Update(id, model);
        return Ok(new { message = "Person updated" });
    }

    // DELETE: api/Person/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _personService.Delete(id);
        return Ok(new { message = "Person deleted" });
    }
}