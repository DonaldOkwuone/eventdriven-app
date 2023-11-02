using CommandService.Models;

namespace CommandService.Repository
{
    public interface ICommandRepository
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int Id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
        Task SaveChanges();

    }
}