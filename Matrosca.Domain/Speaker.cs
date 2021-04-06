using System.Collections.Generic;

namespace Matrosca.Domain
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageURL { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public List<SocialMedia> SocialMedia { get; set; }
        public List<SpeakerHasEvent> SpeakeEvents { get; set; }
    }
}