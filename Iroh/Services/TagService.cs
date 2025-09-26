using Iroh.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;

namespace Iroh.Services
{
    public class TagService(ApplicationDbContext context) : ITagService
    {
        public readonly ApplicationDbContext _context = context;

        public static List<Tag> AllTags = [];

        public async Task<List<Tag>> GetTagsByFamilies(TagFamily[] families)
        {
            if(AllTags.Count == 0)
            {
                AllTags = await _context.Tags.ToListAsync();
                Console.WriteLine("TAGS INITIALISIERT.");
                return AllTags.Where(tag => families.Contains(tag.Family)).ToList();
            }
            return AllTags.Where(tag => families.Contains(tag.Family)).ToList();    
        }

        public Subject GetEnumByString(string name)
        {
            Subject[] apps = (Subject[])Enum.GetValues(typeof(Subject));
            foreach (Subject app in apps)
            {
                if (app.ToString() == name)
                {
                    return app;
                }
            }
            return Subject.Any;
        }

        public TagFamily[] GetSubjectFamilies(Subject page)
        {
            JsonFileHandler _jsonFileHandler = new JsonFileHandler();
            Associations a = _jsonFileHandler.LoadAssociations();
            
            if (a.AssDictionary.TryGetValue(page, out TagFamily[]? value))
            {
                return value;
            }
            return new TagFamily[0];
        }


        public class Associations
        {
            public required Dictionary<Subject, TagFamily[]> AssDictionary { get; set; }
        }
        public class JsonFileHandler
        {
            private const string FilePath = "wwwroot/tag_family_associations.json";

            public Associations LoadAssociations()
            {
                if (!File.Exists(FilePath))
                {
                    return new Associations { AssDictionary = new Dictionary<Subject, TagFamily[]>() };
                }

                var json = File.ReadAllText(FilePath);
                Associations? ret = JsonSerializer.Deserialize<Associations>(json);
                Debug.Assert(ret != null, "Import of Tag Family associations failed. Check TagService.cs or wwwroot/tag_family_associations.json");
                return ret;
            }
        }
    }
}
