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
            Dictionary<UsedInApp, TagFamily[]> combinations = new Dictionary<UsedInApp, TagFamily[]>
            {
                { UsedInApp.Writing, [TagFamily.Writing, TagFamily.Region, TagFamily.Time, TagFamily.Topic, TagFamily.Science, TagFamily.Sport, TagFamily.FictionGenre, TagFamily.Fiction, TagFamily.Genre] },
                { UsedInApp.Person, [TagFamily.Person, TagFamily.Region, TagFamily.Time, TagFamily.Sport, TagFamily.Science, TagFamily.Topic, TagFamily.Fiction] },
                { UsedInApp.Art, [TagFamily.Art, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { UsedInApp.Place, [TagFamily.Place, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { UsedInApp.Event, [TagFamily.Event, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { UsedInApp.MotionPicture, [TagFamily.MotionPicture, TagFamily.Region, TagFamily.Time, TagFamily.Topic, TagFamily.Science, TagFamily.Sport, TagFamily.FictionGenre, TagFamily.Genre] },
                { UsedInApp.Music, [TagFamily.Music, TagFamily.Region, TagFamily.Time, TagFamily.MusicGenre] },
                { UsedInApp.VideoGame, [TagFamily.Region, TagFamily.FictionGenre, TagFamily.VideoGameGenre] },
                { UsedInApp.Plant, [TagFamily.Plant, TagFamily.Region, TagFamily.Fiction] },
                { UsedInApp.Animal, [TagFamily.Animal, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { UsedInApp.Game, [TagFamily.Game, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] }

            };
            if (combinations.ContainsKey(page))
            {
                return combinations[page];
            }
            return new TagFamily[0];
        }
        /*public List<int> GetTagsByThing(int thingId)
        {
            List<Description> descriptions = _context.Descriptions.Where(desc => desc.ThingId == thingId).ToList();
            List<int> tagIds = descriptions.Select(d => d.TagId).ToList();
            return tagIds;
        }*/
        public List<Tag> GetTagsByThing(int thingId)
        {
            List<Description> descriptions = _context.Descriptions.Where(desc => desc.ThingId == thingId).ToList();
            List<int> tagIds = descriptions.Select(d => d.TagId).ToList();
            List<Tag> tags = _context.Tags.Where(t => tagIds.Contains(t.Id)).ToList();
            return tags;
        }
    }
}
