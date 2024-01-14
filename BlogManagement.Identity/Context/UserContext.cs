using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Identity.Context;

public class UserContext : IdentityDbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {

    }
}
