using finaltry.models.entity;
using Microsoft.EntityFrameworkCore;

namespace finaltry.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {  
        }
        public DbSet<Student> students { get; set; }
    }
}
