using Iroh.Data;

namespace Iroh.Services
{
    public interface ISearchThingService
    {
        public Task<List<Thing>> GetAll();
        public Task<List<Tag>> AllTags();
        public Task<List<Thing>> GetThingsByTags(List<int> tags, string sortBy);
    }
}