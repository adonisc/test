namespace WebApi.Models.Persons;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    //[Required]
    //[EnumDataType(typeof(Role))]
    [Required]
    public string Gender { get; set; }
    //public string Role { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Country { get; set; }

    // [Required]
    // [MinLength(6)]
    // public string Password { get; set; }

    // [Required]
    // [Compare("Password")]
    // public string ConfirmPassword { get; set; }
}