using Iroh.Data;
using Serilog;

namespace Iroh.Helpers
{
    public class ThingQuerier
    {
        private readonly ApplicationDbContext _context;
        private readonly Serilog.ILogger _logger;
        public ThingQuerier(ApplicationDbContext context)
        {
            _context = context;
            _logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        private int _skipItems = 0;
        private int _itemsPerPage = 20;
        public IQueryable<Thing> GetSortedThings(List<int> chosentags, int currentPage = 1, string sortBy = "Upvotes")
        {
            _logger.Information($"InsideQuerier: sortBy == {sortBy}");
            _skipItems = (currentPage - 1) * _itemsPerPage;

            IQueryable<Thing> query = SortThings(GetThingsByTags(chosentags), sortBy);
            return query;
        }
        private IQueryable<Thing> GetThingsByTags(IEnumerable<int> tagIds)
        {

            var things = _context.Descriptions
                .Where(description => tagIds.Contains(description.TagId))
                .GroupBy(description => description.ThingId)
                .Where(group => group.Count() == tagIds.Count())
                .Select(group => group.Key);

            return _context.Things.Where(thing => things.Contains(thing.Id));
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
            _logger.Information("Sort by New");
            return things.OrderByDescending(t => t.CreatedAt)
                                                .Select(t => t)
                                                .Skip(_skipItems)
                                                .Take(_itemsPerPage);
        }
        private IQueryable<Thing> SortByUpvotes(IQueryable<Thing> things)
        {
            _logger.Information("Sort by Upvotes");
            return things.OrderByDescending(t => t.Upvotes)
                                                .Skip(_skipItems)
                                                .Take(_itemsPerPage);
        }

    }
}
