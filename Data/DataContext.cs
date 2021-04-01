using Microsoft.EntityFrameworkCore;
using Matrosca.API.Model;

namespace Matrosca.API.Data
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        
        public DbSet<Event> Events { get; set; }
    }
}