using Iroh.Data;
using Serilog;

namespace Iroh.Services
{
    public class ThingService(ApplicationDbContext context) : IThingService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task CreateAsync(Thing thing)
        {
            try
            {
                _context.Things.Add(thing);
                await _context.SaveChangesAsync();
                Log.Information("Created: {@thing}", thing);
            }
            catch (Exception)
            {
                Log.Error("Create failed: {@thing}", thing);
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                var toDelete = await _context.Things.FindAsync(id);
                if (toDelete != null)
                {
                    _context.Things.Remove(toDelete);
                    await _context.SaveChangesAsync();
                    Log.Information($"Deleted: {toDelete}");
                    return;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                Log.Error($"Deleting failed: {id}");
                throw;
            }
        }
        public async Task UpdateAsync(Thing thing, int id)
        {
            try
            {
                var toUpdate = await _context.Things.FindAsync(id);
                if (toUpdate != null)
                {
                    toUpdate.Name = thing.Name;
                    toUpdate.Description = thing.Description;
                    //toUpdate.App = thing.App;
                    await _context.SaveChangesAsync();
                    Log.Information($"Updated: {thing}");
                    return;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                Log.Error($"Updating failed: {thing}");
                throw;
            }
        }
        public async Task<Thing> FindAsync(int id)
        {
            try
            {
                var thing = await _context.Things.FindAsync(id);
                if (thing != null)
                {
                    return thing;
                }
                throw new InvalidDataException("Thing not found.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
