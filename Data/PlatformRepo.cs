using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context) => _context = context;

        public void CreatePlatform(Platform platObj)
        {
            if(platObj == null )throw new NullReferenceException("Platform object is null");
            _context.Add<Platform>(platObj);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(a => a.Id == id);
        }

        public bool SaveChanges() => (_context.SaveChanges() >= 0);
    }

}