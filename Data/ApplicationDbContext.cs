using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using VisitorManagementStudent2022.Models;

namespace VisitorManagementStudent2022.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StaffNames>? StaffNames { get; set; }
        public DbSet<Visitors>? Visitors { get; set; }
    }
}