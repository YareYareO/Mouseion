using Iroh.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Iroh.Services
{
    public class TagService(ApplicationDbContext context) : ITagService
    {
        private readonly ApplicationDbContext _context = context;

        public UsedInApp GetEnumByString(string name) 
        {
            UsedInApp[] apps = (UsedInApp[])Enum.GetValues(typeof(UsedInApp));
            foreach (UsedInApp app in apps)
            {
                if (app.ToString() == name)
                {
                    return app;
                }
            }
            return UsedInApp.Any;
        }
        public TagFamily[] GetTagFamilies(UsedInApp page) 
        {
            string pageString = page.ToString();
            Dictionary<string, TagFamily[]> combinations = new Dictionary<string, TagFamily[]>
            {
                { "Writing", [TagFamily.Writing, TagFamily.Region, TagFamily.Time, TagFamily.Topic, TagFamily.Science, TagFamily.Sport, TagFamily.FictionGenre, TagFamily.Fiction] },
                { "Person", [TagFamily.Person, TagFamily.Region, TagFamily.Time] }
            };
            if (combinations.ContainsKey(pageString))
            {
                return combinations[pageString];
            }
            return new TagFamily[0];
        }
        public List<int> GetTagsByThing(int thingId)
        {
            List<Description> descriptions = _context.Descriptions.Where(desc => desc.ThingId == thingId).ToList();
            List<int> tagIds = descriptions.Select(d => d.TagId).ToList();
            return tagIds;
        }
    }
}
