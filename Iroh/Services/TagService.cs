using Iroh.Data;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Diagnostics;
using System.Text.Json;

namespace Iroh.Services
{
    public class TagService() : ITagService
    {
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

        /* public TagFamily[] GetTagFamilies(Subject page)
        {
            Dictionary<Subject, TagFamily[]> combinations = new Dictionary<Subject, TagFamily[]>
            {
                { Subject.Place, [TagFamily.Place, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { Subject.Event, [TagFamily.Event, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },

                { Subject.Person, [TagFamily.Person, TagFamily.Region, TagFamily.Time, TagFamily.Sport, TagFamily.Science, TagFamily.Topic, TagFamily.Fiction] },
                { Subject.Animal, [TagFamily.Animal, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { Subject.Plant, [TagFamily.Plant, TagFamily.Region, TagFamily.Fiction] },

                { Subject.Art, [TagFamily.Art, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { Subject.Writing, [TagFamily.Writing, TagFamily.Region, TagFamily.Time, TagFamily.Topic, TagFamily.Science, TagFamily.Sport, TagFamily.Fiction, TagFamily.Genre] },
                { Subject.Book, [TagFamily.Book, TagFamily.Region, TagFamily.Time, TagFamily.Fiction, TagFamily.Science, TagFamily.Sport, TagFamily.FictionGenre] },
                { Subject.Invention, [TagFamily.Invention, TagFamily.Region, TagFamily.Time, TagFamily.Fiction, TagFamily.Science] },
                { Subject.MotionPicture, [TagFamily.MotionPicture, TagFamily.Region, TagFamily.Time, TagFamily.Topic, TagFamily.Science, TagFamily.Sport, TagFamily.FictionGenre, TagFamily.Genre] },
                { Subject.Music, [TagFamily.Music, TagFamily.Region, TagFamily.Time, TagFamily.MusicGenre] },
                //{ Subject.VideoGame, [TagFamily.Region, TagFamily.FictionGenre, TagFamily.VideoGameGenre] },
                { Subject.Game, [TagFamily.Game, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] }

            };
            if (combinations.ContainsKey(page))
            {
                return combinations[page];
            }
            return new TagFamily[0];
        } */
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
