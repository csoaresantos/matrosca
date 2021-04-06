using System.Threading.Tasks;
using Matrosca.Domain;

namespace Matrosca.Repository
{
    public interface IMatroscaRepository
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;

        Task<bool> SaveChangesAsync();

        Task<Event[]> GetAllEventAsyncByTheme(string theme, bool includeSpeakers);
        Task<Event[]> GetAllEventAsync(bool includeSpeakers);
        Task<Event> GetEventAsyncById(int EventId, bool includeSpeakers);

        Task<Event[]> GetAllSpeakerAsyncByName(bool includeSpeakers);
        Task<Event> GetSpeakerAsync(int SpeakerId, bool includeSpeakers);

    }
}