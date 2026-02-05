using Microsoft.AspNetCore.Identity;

namespace PropertyMaintenance.Web.Services;

public static class RoleSeeder
{
    private static readonly string[] Roles = ["Owner", "Admin", "Technician", "Client"];

    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
