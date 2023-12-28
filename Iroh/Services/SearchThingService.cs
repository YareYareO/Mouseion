using Iroh.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}
