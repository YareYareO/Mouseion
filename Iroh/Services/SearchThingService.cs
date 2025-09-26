using Iroh.Data;
using Microsoft.EntityFrameworkCore;

namespace Iroh.Services
{
    public class SearchThingService(ApplicationDbContext context) : ISearchThingService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<List<Thing>> GetThingsByTags(List<int> tags, string sortBy, Subject subject, int currentPage)
        {
            var things = from description in _context.Descriptions
                where tags.Contains(description.TagId)
                group description by description.ThingId into g
                where g.Count() == tags.Count()
                select g.Key;

            var result = (from thing in _context.Things
                          where thing.App == subject && things.Contains(thing.Id)
                          orderby thing.CreatedAt
                          select new { thing.Name, thing.Description })
                    .Skip((currentPage - 1) * 15)
                    .Take(15)
                    .Select(x => new Thing { Name = x.Name, Description = x.Description })
                    .AsNoTracking();
                    
            return await result.ToListAsync();
        }
        public async Task<List<Thing>> GetThingsNoTags(string sortBy, Subject subject, int currentPage)
        {
            var idk = from thing in _context.Things
                where thing.App == subject
                orderby thing.CreatedAt
                select new { thing.Name, thing.Description }; 
            var result = await idk
                    .Skip((currentPage - 1) * 15)
                    .Take(15)
                    .Select(x => new Thing { Name = x.Name, Description = x.Description }).AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<List<Thing>> GetThingsByCreator(string creator)
        {
            var things = await _context.Things.Where(thing =>  thing.Creator.Equals(creator)).ToListAsync();

            return things;
        }
    }
}
