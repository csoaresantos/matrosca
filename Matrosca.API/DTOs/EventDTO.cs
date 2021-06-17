using System.Collections.Generic;

namespace Matrosca.API.DTOs
{
    public class EventDTO
    {
        public int EventId { get; set; }

        public string Local { get; set; }

        public string DataEvent { get; set; }

        public string Theme { get; set; }

        public int PeopleQty { get; set; }

        public string ImageUrl { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }
        
        public List<LoteDTO> Lotes { get; set; }
        public List<SocialMediaDTO> SocialMedias { get; set; }
        public List<SpeakerDTO> Speakes { get; set; }
    }
}