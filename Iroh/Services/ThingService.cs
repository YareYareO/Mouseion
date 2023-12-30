using Iroh.Data;
using Serilog;

namespace Iroh.Services
{
    public class ThingService(ApplicationDbContext context) : IThingService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<bool> CreateAsync(Thing thing)
        {
            try
            {
                _context.Things.Add(thing);
                await _context.SaveChangesAsync();
                Log.Information("Created: {@thing}", thing);
                return true;
            }
            catch (Exception)
            {
                Log.Error("Create failed: {@thing}", thing);
                throw;
            }


        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var toDelete = await _context.Things.FindAsync(id);
                if (toDelete != null)
                {
                    _context.Things.Remove(toDelete);
                    await _context.SaveChangesAsync();
                    Log.Information($"Deleted: {toDelete}");
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                Log.Error($"Deleting failed: {id}");
                throw;
            }
        }


        public async Task<bool> UpdateAsync(Thing thing)
        {
            try
            {
                var toUpdate = await _context.Things.FindAsync(thing.Id);
                if (toUpdate != null)
                {
                    toUpdate.Name = thing.Name;
                    toUpdate.Description = thing.Description;
                    toUpdate.App = thing.App;
                    await _context.SaveChangesAsync();
                    Log.Information($"Updated: {thing}");
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                Log.Error($"Updating failed: {thing}");
                throw;
            }
        }
    }
}
