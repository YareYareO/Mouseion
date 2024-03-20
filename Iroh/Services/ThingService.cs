using Iroh.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace Iroh.Services
{
    public class ThingService(ApplicationDbContext context) : IThingService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<int> CreateAsync(Thing thing)
        {
            try
            {
                thing.CreatedAt = DateTime.Now;
                _context.Things.Add(thing);
                await _context.SaveChangesAsync();
                Log.Information("Created: {@thing}", thing);
                return thing.Id;
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
        public async Task UpdateDescriptions(List<int> chosenTags, int thingId)
        {
                var oldDescriptions = await _context.Descriptions
                                    .Where(d => d.ThingId == thingId)
                                    .ToListAsync();

                // Determine tags for addition and removal
                var tagsToAdd = chosenTags.Except(oldDescriptions.Select(d => d.TagId));
                var tagsToRemove = oldDescriptions.Where(d => !chosenTags.Contains(d.TagId))
                    .Select(d => d.TagId);

                // Add new descriptions in a single batch
                foreach (int tagId in tagsToAdd)
                {
                    _context.Descriptions.Add(new Description { ThingId = thingId, TagId = tagId });
                }

                // Remove old descriptions efficiently
                _context.Descriptions.RemoveRange(oldDescriptions.Where(d => tagsToRemove.Contains(d.TagId)));

                // Save changes in a single operation
                await _context.SaveChangesAsync();
        }
    }

}
