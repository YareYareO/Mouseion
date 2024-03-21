using Iroh.Data;
using Microsoft.EntityFrameworkCore;
using Iroh.Helpers;
using System.Diagnostics;

namespace Iroh.Services
{
    public class SearchThingService(ApplicationDbContext context) : ISearchThingService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Tag>> AllTags()
        {
            var tags = await _context.Tags.ToListAsync();
            return tags;
        }
        public async Task<List<Tag>> GetAllTags(UsedInApp app)
        {
            var tags = await _context.Tags.Where(tag => (tag.App == app) | (tag.App == UsedInApp.Both)).ToListAsync();
            return tags;
        }

        public async Task<List<Thing>> GetThingsByTags(List<int> tags, string sortBy, UsedInApp app)
        {
            Debug.WriteLine(sortBy);
            foreach(int tag in tags)
            {
                Debug.WriteLine(tag);
            }
            Debug.WriteLine(app);
            ThingQuerier querier = new ThingQuerier(context: _context, chosentags: tags, currentPage: 1, sortBy: sortBy, app: app);
            var things = await querier.GetSortedThings().ToListAsync();
            return things;
        }
    }
}
