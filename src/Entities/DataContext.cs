using Microsoft.EntityFrameworkCore;

namespace owasp_topten_api.Entities
{
    public class DataContext:DbContext
    {

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=DB\\Database.db");
    }
        
    }
}