using Iroh.Data;

namespace Iroh.Services
{
    public interface ISearchThingService
    {
        public Task<List<Thing>> GetAll();
    }
}