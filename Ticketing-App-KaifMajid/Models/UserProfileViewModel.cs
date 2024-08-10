namespace WebApplication1.Models;

public class UserProfileViewModel
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
    public string Password_Hash { get; set; }

    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Postal_Code { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
}