using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Node, NodeDTO>();
            CreateMap<Journal, JournalDTO>();
            CreateMap<Journal, JournalInfoDTO>();
        }
    }
}
