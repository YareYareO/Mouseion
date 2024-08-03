using Iroh.Data;


namespace Iroh.Helpers
{
    public class ThingQuerier
    {
        private readonly ApplicationDbContext _context;
        private UsedInApp app;
        private List<int> chosentags;
        private int currentPage;
        private string sortBy;
        private int skipItems;
        private int itemsPerPage;
        public ThingQuerier(ApplicationDbContext context, List<int> chosentags, int currentPage, string sortBy, UsedInApp app)
        {
            _context = context;
            this.app = app;
            this.chosentags = chosentags;
            this.currentPage = currentPage;
            this.sortBy = sortBy;

            skipItems = 0;
            itemsPerPage = 20;
        }

        public IQueryable<Thing> GetSortedThings()
        {
            skipItems = (this.currentPage - 1) * this.itemsPerPage;
            IQueryable<Thing> query = SortThings(GetThingsByTags(this.chosentags), this.sortBy);
            return query;
        }
        private IQueryable<Thing> GetThingsByTags(IEnumerable<int> tagIds)
        {
            var things = _context.Descriptions
                .Where(description => tagIds.Contains(description.TagId))
                .GroupBy(description => description.ThingId)
                .Where(group => group.Count() == tagIds.Count())
                .Select(group => group.Key);

            if(tagIds.Count() == 0)
            {
                return _context.Things.Where(thing => thing.App == this.app);
            }
            return _context.Things.Where(thing => (thing.App == this.app) & things.Contains(thing.Id));
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
                                                .Skip(skipItems)
                                                .Take(itemsPerPage);
        }
        private IQueryable<Thing> SortByUpvotes(IQueryable<Thing> things)
        {
            return things.OrderByDescending(t => t.Upvotes)
                                                .Skip(skipItems)
                                                .Take(itemsPerPage);
        }

        
    }
}
