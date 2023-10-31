using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Repository
{
    public class CreatePlatformProfile : Profile
    {
        public CreatePlatformProfile()
        {
            CreateMap<PlatformDto, Platform>();
        }
    }
}