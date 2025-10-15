using Microsoft.AspNetCore.Identity;

namespace MovieApi.Persistence.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ImageUrl { get; set; }
}