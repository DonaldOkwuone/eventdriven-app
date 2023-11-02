using AutoMapper;
using CommandService.Data;
using CommandService.Models;

namespace CommandService.MapperProfiles
{
    public class CommandServiceProfile : Profile
    {
        public CommandServiceProfile()
        {
            CreateMap<CommandCreateDto, Command>();
        }
    }
}