using System.Diagnostics;
using Iroh.Data;

namespace Iroh.Helpers
{
    public class ThingQuerier
    {
        private readonly ApplicationDbContext _context;
        private Subject subject;
        private List<int>? chosentags;
        private int currentPage;
        private string sortBy;
        private int skipItems;
        private int itemsPerPage;
        
        public ThingQuerier(ApplicationDbContext context, List<int> chosentags, int currentPage, string sortBy, Subject subject)
        {
            _context = context;
            this.subject = subject;
            this.chosentags = chosentags;
            this.currentPage = currentPage;
            this.sortBy = sortBy;

            skipItems = 0;
            itemsPerPage = 20;
            
        }
        public ThingQuerier(ApplicationDbContext context, int currentPage, string sortBy, Subject subject)
        {
            _context = context;
            this.subject = subject;
            this.currentPage = currentPage;
            this.sortBy = sortBy;
            this.chosentags = null;
            skipItems = 0;
            itemsPerPage = 20;
            
        }

        public IQueryable<Thing> GetSortedThings()
        {
            this.skipItems = (this.currentPage - 1) * this.itemsPerPage;
            IQueryable<Thing> query;
            if (this.chosentags == null)
            {
                query = SortByNew(GetThingsNoTags());
            }else{
                query = SortByNew(GetThingsByTags(this.chosentags));
            }
            return query;
        }
        private IQueryable<Thing> GetThingsNoTags()
        {
            Debug.Assert(_context.Things != null);
            return _context.Things.Where(thing => thing.App == this.subject);
        }
        private IQueryable<Thing> GetThingsByTags(IEnumerable<int> tagIds)
        {
            Debug.Assert(_context.Things != null);
            Debug.Assert(_context.Descriptions != null);
            var things = _context.Descriptions
                .Where(description => tagIds.Contains(description.TagId))
                .GroupBy(description => description.ThingId)
                .Where(group => group.Count() == tagIds.Count())
                .Select(group => group.Key);

            return _context.Things.Where(thing => (thing.App == this.subject) & things.Contains(thing.Id));
        }
        private IQueryable<Thing> SortThings(IQueryable<Thing> things, string sortBy)
        {
            Dictionary<string, Func<IQueryable<Thing>, IQueryable<Thing>>> sortingoptions = new Dictionary<string, Func<IQueryable<Thing>, IQueryable<Thing>>>();
            sortingoptions["Upvotes"] = (t) => SortByUpvotes(t);
            sortingoptions["New"] = (t) => SortByNew(t);

            if (sortingoptions.ContainsKey(sortBy))
            {
                things = sortingoptions[sortBy](things);
            }

            return things;
        }

        private IQueryable<Thing> SortByNew(IQueryable<Thing> things)
        {
            return things.OrderByDescending(t => t.CreatedAt)
                                                .Select(t => t)
                                                .Skip(this.skipItems)
                                                .Take(this.itemsPerPage);
        }
        private IQueryable<Thing> SortByUpvotes(IQueryable<Thing> things)
        {
            return things.OrderByDescending(t => t.Upvotes)
                                                .Skip(skipItems)
                                                .Take(itemsPerPage);
        }

        
    }
}