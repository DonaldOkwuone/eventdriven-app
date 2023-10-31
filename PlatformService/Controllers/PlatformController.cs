using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.Repository;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }
        [Route("GetAllPlatform")]
        public IActionResult GetAllPlatform()
        {
            return Ok(_platformRepository.getAllPlatform());
        }

        public async Task<IActionResult> CreatePlatform(PlatformDto platformdto)
        {
            Platform platform = _mapper.Map<PlatformDto, Platform>(platformdto);
            _platformRepository.CreatePlatform(platform);
            await _platformRepository.SaveChanges();

            return Ok(platform);
        }
    }
}