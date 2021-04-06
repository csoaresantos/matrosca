using System.Linq;
using System.Threading.Tasks;
using Matrosca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Matrosca.Repository
{
    public class MatroscaRepository : IMatroscaRepository
    {
        private readonly MatroscaContext _context;

        public MatroscaRepository(MatroscaContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Event[]> GetAllEventAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(c => c.Lotes)
            .Include(c => c.SocialMedias);

            if (includeSpeakers)
            {
                query = query
                .Include(pe => pe.SpeakeEvents)
                .ThenInclude(p => p.Speaker);
            }

            query = query.OrderByDescending(c => c.DataEvent);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventAsyncByTheme(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(c => c.Lotes)
            .Include(c => c.SocialMedias);

            if (includeSpeakers)
            {
                query = query
                .Include(pe => pe.SpeakeEvents)
                .ThenInclude(e => e.Speaker);
            }

            query = query.OrderByDescending(c => c.DataEvent)
            .Where(c => c.Theme.Contains(theme));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventAsyncById(int eventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(c => c.Lotes)
                .Include(c => c.SocialMedias);

            if (includeSpeakers)
            {
                query = query
                .Include(pe => pe.SpeakeEvents)
                .ThenInclude(e => e.Speaker);
            }

            query = query.OrderByDescending(e => e.DataEvent)
            .Where(o => o.EventId == eventId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Speaker[]> GetAllSpeakerAsyncByName(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
            .Include(c => c.SocialMedia);

            if (includeEvents)
            {
                query = query.Include(pe => pe.SpeakeEvents).ThenInclude(e => e.Event);
            }

            query = query.OrderBy(s => s.Name)
            .Where(s => s.Name.ToLower().Equals(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerAsync(int speakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers.Include(c => c.SocialMedia);

            if (includeEvents)
            {
                query = query.Include(pe => pe.SpeakeEvents).ThenInclude(e => e.Event);
            }

            query = query.OrderBy(s => s.Name).Where(p => p.Id == speakerId);

            return await query.FirstOrDefaultAsync();
        }
    }
}