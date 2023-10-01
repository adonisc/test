namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Persons;

public interface IPersonService
{
    IEnumerable<Person> GetAll();
    Person GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class PersonService : IPersonService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public PersonService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Person> GetAll()
    {
        return _context.Persons;
    }

    public Person GetById(int id)
    {
        return getPerson(id);
    }

    public void Create(CreateRequest model)
    {
        // validate
        if (_context.Persons.Any(x => x.Email == model.Email))
            throw new AppException("Person with the email '" + model.Email + "' already exists");

        // map model to new person object
        var person = _mapper.Map<Person>(model);

        // save person
        _context.Persons.Add(person);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var person = getPerson(id);

        // validate
        if (model.Email != person.Email && _context.Persons.Any(x => x.Email == model.Email))
            throw new AppException("Person with the email '" + model.Email + "' already exists");


        // copy model to person and save
        _mapper.Map(model, person);
        _context.Persons.Update(person);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var person = getPerson(id);
        _context.Persons.Remove(person);
        _context.SaveChanges();
    }

    // helper methods

    private Person getPerson(int id)
    {
        var person = _context.Persons.Find(id);
        if (person == null) throw new KeyNotFoundException("Person not found");
        return person;
    }
}