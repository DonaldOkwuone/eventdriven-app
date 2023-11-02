using AutoMapper;
using CommandService.Data;
using CommandService.Models;
using CommandService.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _mapper;

        public CommandController(ICommandRepository commandRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _mapper = mapper;
        }
        [Route("Commands")]
        public IActionResult Commands()
        {
            return Ok(_commandRepository.GetAllCommands());
        }
        [Route("{id}", Name = "CommandById")]
        public IActionResult CommandById(int Id)
        {

            return Ok(_commandRepository.GetCommandById(Id));
        }

       // [Route("CreateCommand")]
        [HttpPost]
        public IActionResult CreateCommand([FromBody] CommandCreateDto commandDto)
        {
            Console.WriteLine("-->Hittin create endpoint");
            var command = _mapper.Map<Command>(commandDto);
            _commandRepository.CreateCommand(command);
            try
            {
                _commandRepository.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong {e.Message}");
            }

            return Created("/Command/CreateCommand", command);
        }
    }
}