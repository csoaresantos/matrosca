using Matrosca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Matrosca.Repository
{
   public class MatroscaContext : DbContext
    {
        public MatroscaContext(DbContextOptions<MatroscaContext> options): base(options){}
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerHasEvent> SpeakerHasEvents { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerHasEvent>().HasKey(SP=> new { SP.EventId, SP.SpeakerId });
        }
    }
}