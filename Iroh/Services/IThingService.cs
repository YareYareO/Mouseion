using Iroh.Data;

namespace Iroh.Services
{
    public interface IThingService
    {
        public Task<bool> CreateAsync(Thing thing);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(Thing thing);
    }
}
