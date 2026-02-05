using Microsoft.AspNetCore.Identity;

namespace PropertyMaintenance.Web.Models;

public class ApplicationUser : IdentityUser
{
    public CustomerProfile? CustomerProfile { get; set; }
}
