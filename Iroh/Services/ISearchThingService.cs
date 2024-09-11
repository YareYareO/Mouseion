using Iroh.Data;

namespace Iroh.Services
{
    public interface ISearchThingService
    {
        //public Task<List<Tag>> AllTags();

        //public Task<List<Tag>> GetTagsByApp(UsedInApp app);
        public Task<List<Tag>> GetTagsByFamilies(TagFamily[] app);
        public Task<List<Thing>> GetThingsByTags(List<int> tags, string sortBy, UsedInApp app, int currentPage);
        public Task<List<Thing>> GetThingsByCreator(string  creator);
    }
}