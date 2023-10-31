using PlatformService.Models;

namespace PlatformService.Repository
{
    public interface IPlatformRepository
    {
        IEnumerable<Platform> getAllPlatform();
        Platform getPlatformById(int Id);

        void UpdatePlatform(Platform platform);
        void DeletePlatform(int Id);
        void CreatePlatform(Platform platform);
        Task SaveChanges();


    }
}