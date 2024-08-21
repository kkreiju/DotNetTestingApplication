using Microsoft.EntityFrameworkCore;
using test.Models.Entities;

namespace test.Data
{
    public class ApplicationDBContext : DbContext
    { 
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }

        //23:10
        public DbSet<StudentIdentity> Students { get; set; }
    }
}
