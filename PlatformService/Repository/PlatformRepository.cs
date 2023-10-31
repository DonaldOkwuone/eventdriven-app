using PlatformService.Models;

namespace PlatformService.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;

        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform platform)
        {
            _context.platforms.Add(platform);
        }

        public void DeletePlatform(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Platform> getAllPlatform()
        {
            return _context.platforms.ToList();
        }

        public Platform getPlatformById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdatePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }


    }
}