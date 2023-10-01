namespace WebApi.Models.Persons;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UpdateRequest
{
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Gender { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Country { get; set; }

    // helpers

    private string replaceEmptyWithNull(string value)
    {
        // replace empty string with null to make field optional
        return string.IsNullOrEmpty(value) ? null : value;
    }
}