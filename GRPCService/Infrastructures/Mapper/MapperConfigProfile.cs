using AutoMapper;
using GRPCService.Entities;
using GRPCService.Protos;

namespace GRPCService.Infrastructures.Mapper
{
    public class MapperConfigProfile : Profile
    {
        public MapperConfigProfile()
        {
            CreateMap<Offer, OfferDetail>().ReverseMap();
            CreateMap<Offer, UserOfferDetail>().ReverseMap();
        }
    }
}
