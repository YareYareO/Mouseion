using Iroh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Iroh.Helpers;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Iroh.Services
{
    public class SearchThingService(ApplicationDbContext context) : ISearchThingService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<List<Tag>> GetTagsByFamilies(TagFamily[] family)
        {
            var tags = await _context.Tags.Where(tag => family.Contains(tag.Family)).ToListAsync();
            return tags;
        }

        public async Task<List<Thing>> GetThingsByTags(List<int> tags, string sortBy, UsedInApp app)
        {
            ThingQuerier querier = new ThingQuerier(context: _context, chosentags: tags, currentPage: 1, sortBy: sortBy, app: app);
            var things = await querier.GetSortedThings().ToListAsync();
            return things;
        }
        public async Task<List<Thing>> GetThingsByCreator(string creator)
        {
            var things = await _context.Things.Where(thing =>  thing.Creator.Equals(creator)).ToListAsync();

            return things;
        }
    }
}
