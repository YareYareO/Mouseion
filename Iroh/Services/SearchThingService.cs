using Iroh.Data;
using Microsoft.EntityFrameworkCore;
using Iroh.Helpers;

namespace Iroh.Services
{
    public class SearchThingService(ApplicationDbContext context) : ISearchThingService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Thing>> GetAll()
        {
            var things = await _context.Things.ToListAsync();
            return things;
        }
        public async Task<List<Tag>> AllTags()
        {
            var tags = await _context.Tags.ToListAsync();
            return tags;
        }

        public async Task<List<Thing>> GetThingsByTags(List<int> tags, string sortBy)
        {
            ThingQuerier querier = new ThingQuerier(_context);
            var things = await querier.GetSortedThings(chosentags: tags, sortBy: sortBy).ToListAsync();
            return things;
        }
    }
}
