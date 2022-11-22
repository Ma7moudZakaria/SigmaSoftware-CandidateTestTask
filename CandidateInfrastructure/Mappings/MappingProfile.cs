using AutoMapper;
using CandidateDomain.Features.SaveCandidate.DTO;
using CandidateEntites.Entities;

namespace CandidateInfrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SaveCandidateInformationDTO, Candidate>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src) => Guid.NewGuid()));
        }
    }
}
