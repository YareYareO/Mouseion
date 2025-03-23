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
        public async Task<List<Tag>> GetTagsByFamilies(TagFamily[] families)
        {
            var tags = await _context.Tags.Where(tag => families.Contains(tag.Family)).ToListAsync();
            return tags;
        }

        public async Task<List<Thing>> GetThingsByTags(List<int> tags, string sortBy, Subject subject, int currentPage)
        {
            ThingQuerier querier = new ThingQuerier(context: _context, chosentags: tags, currentPage: currentPage, sortBy: sortBy, subject: subject);
            var things = await querier.GetSortedThings().ToListAsync();
            //var things = querier.GetByDapper().ToList();
            return things;
        }
        public async Task<List<Thing>> GetThingsNoTags(string sortBy, Subject subject, int currentPage)
        {
            ThingQuerier querier = new ThingQuerier(context: _context, currentPage: currentPage, sortBy: sortBy, subject: subject);
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
