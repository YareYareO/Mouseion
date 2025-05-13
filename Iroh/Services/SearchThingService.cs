using Iroh.Data;
using Microsoft.EntityFrameworkCore;
//using Iroh.Helpers;

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
            //ThingQuerier querier = new ThingQuerier(context: _context, chosentags: tags, currentPage: currentPage, sortBy: sortBy, subject: subject);
            //var things = await querier.GetSortedThings().ToListAsync();
            var things = from description in _context.Descriptions
              where tags.Contains(description.TagId)
              group description by description.ThingId into g
              where g.Count() == tags.Count()
              select g.Key;

            var idk = (from thing in _context.Things
                    where thing.App == subject && things.Contains(thing.Id)
                    orderby thing.CreatedAt
                    select new { thing.Name, thing.Description })
                    .Select(x => new Thing { Name = x.Name, Description = x.Description });
                    
            return await idk.ToListAsync();
        }
        public async Task<List<Thing>> GetThingsNoTags(string sortBy, Subject subject, int currentPage)
        {
            //ThingQuerier querier = new ThingQuerier(context: _context, currentPage: currentPage, sortBy: sortBy, subject: subject);
            //var things = await querier.GetSortedThings().ToListAsync();
            var result = from thing in _context.Things
                where thing.App == subject
                orderby thing.CreatedAt
                select new { thing.Name, thing.Description }; 
            var idk = await result.Select(x => new Thing { Name = x.Name, Description = x.Description }).ToListAsync();
            return idk;
            //return things;
        }
        public async Task<List<Thing>> GetThingsByCreator(string creator)
        {
            var things = await _context.Things.Where(thing =>  thing.Creator.Equals(creator)).ToListAsync();

            return things;
        }
    }
}
