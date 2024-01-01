using Iroh.Data;

namespace Iroh.Services
{
    public interface IThingService
    {
        public Task CreateAsync(Thing thing);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(Thing thing, int id);
        public Task<Thing> FindAsync(int id);
    }
}
