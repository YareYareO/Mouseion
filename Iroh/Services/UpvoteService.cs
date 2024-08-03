using Iroh.Data;
using System.Diagnostics;

namespace Iroh.Services
{
    public class UpvoteService(ApplicationDbContext context) : IUpvoteService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<bool> DoesUpvoteExistAlready(int thingId, string userid)
        {
            bool doesExist = _context.Upvotes.Any(u => u.ThingId == thingId & u.UserId == userid);
            return doesExist;
        }
        public async Task<bool> CreateUpvote(int thingId, string userid)
        {
            bool successfulIncrease = false;
            try
            {
                Upvote newUpvote = new Upvote(thingId, userid);
                _context.Upvotes.Add(newUpvote);
                await _context.SaveChangesAsync();
                successfulIncrease = await UpdateThingUpvotes(thingId, true);
            }
            catch { return false; }

            return successfulIncrease;
        }

        private async Task<bool> UpdateThingUpvotes(int thingId, bool increase)
        {
            Thing thing = await _context.Things.FindAsync(thingId);
            try
            {
                thing.Upvotes += increase ? 1 : -1;
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> RemoveUpvote(int thingId, string userid)
        {
            bool successfulDecrease = false;
            try
            {
                Debug.WriteLine("--------------hiii------------");
                Upvote upv = _context.Upvotes.First(x => x.ThingId == thingId & x.UserId == userid);
                Debug.WriteLine(upv.ToString());
                Debug.WriteLine(upv);
                _context.Upvotes.Remove(upv);
                await _context.SaveChangesAsync();
                successfulDecrease = await UpdateThingUpvotes(thingId, false);
            }
            catch { return false; }
            return successfulDecrease;
        }
    }
}
