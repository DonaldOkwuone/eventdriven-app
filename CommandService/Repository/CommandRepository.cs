using AutoMapper;
using CommandService.Data;
using CommandService.Models;

namespace CommandService.Repository
{
    public class CommandRepository : ICommandRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CommandRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void CreateCommand(Command command)
        {
            _context.commands.Add(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.commands.ToList();
        }

        public Command GetCommandById(int Id)
        {
            return _context.commands.Where(x => x.Id == Id).FirstOrDefault();

        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}