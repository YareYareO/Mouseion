using Iroh.Data;

namespace Iroh.Services
{
    public interface ISearchThingService
    {
        public Task<List<Thing>> GetThingsByTags(List<int> tags, string sortBy, Subject subject, int currentPage);
        public Task<List<Thing>> GetThingsNoTags(string sortBy, Subject subject, int currentPage);
        public Task<List<Thing>> GetThingsByCreator(string  creator);
    }
}