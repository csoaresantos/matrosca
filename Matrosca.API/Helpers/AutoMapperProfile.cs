using System.Linq;
using AutoMapper;
using Matrosca.API.DTOs;
using Matrosca.Domain;

namespace Matrosca.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Event, EventDTO>()
            .ForMember(dest => dest.Speakes, opt => {
                opt.MapFrom(src => src.SpeakeEvents.Select(i => i.Speaker).ToArray());
            });

            CreateMap<Lote, LoteDTO>();
            CreateMap<SocialMedia, SocialMediaDTO>();
            CreateMap<Speaker, SpeakerDTO>();
        }
    }
}