using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebEvidencPojistenychDK.Models;

namespace WebEvidencPojistenychDK.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebEvidencPojistenychDK.Models.InsuredPerson> InsuredPerson { get; set; } = default!;
        public DbSet<WebEvidencPojistenychDK.Models.Insurance> Insurance { get; set; } = default!;
        
    }
}
