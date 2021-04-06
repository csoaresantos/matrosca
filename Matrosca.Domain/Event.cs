using System;
using System.Collections.Generic;

namespace Matrosca.Domain
{
    public class Event
    {
        public int EventId { get; set; }

        public string Local { get; set; }

        public DateTime DataEvent { get; set; }

        public string Theme { get; set; }

        public int PeopleQty { get; set; }

        public string ImageUrl { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }
        
        public List<Lote> Lotes { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<SpeakerHasEvent> SpeakeEvents { get; set; }
    }
}