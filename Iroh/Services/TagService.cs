﻿using Iroh.Data;

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
        public TagFamily[] GetTagFamilies(Subject page) 
        {
            Dictionary<Subject, TagFamily[]> combinations = new Dictionary<Subject, TagFamily[]>
            {
                { Subject.Writing, [TagFamily.Writing, TagFamily.Region, TagFamily.Time, TagFamily.Topic, TagFamily.Science, TagFamily.Sport, TagFamily.FictionGenre, TagFamily.Fiction, TagFamily.Genre] },
                { Subject.Person, [TagFamily.Person, TagFamily.Region, TagFamily.Time, TagFamily.Sport, TagFamily.Science, TagFamily.Topic, TagFamily.Fiction] },
                { Subject.Art, [TagFamily.Art, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { Subject.Place, [TagFamily.Place, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { Subject.Event, [TagFamily.Event, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { Subject.MotionPicture, [TagFamily.MotionPicture, TagFamily.Region, TagFamily.Time, TagFamily.Topic, TagFamily.Science, TagFamily.Sport, TagFamily.FictionGenre, TagFamily.Genre] },
                { Subject.Music, [TagFamily.Music, TagFamily.Region, TagFamily.Time, TagFamily.MusicGenre] },
                { Subject.VideoGame, [TagFamily.Region, TagFamily.FictionGenre, TagFamily.VideoGameGenre] },
                { Subject.Plant, [TagFamily.Plant, TagFamily.Region, TagFamily.Fiction] },
                { Subject.Animal, [TagFamily.Animal, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] },
                { Subject.Game, [TagFamily.Game, TagFamily.Region, TagFamily.Time, TagFamily.Fiction] }

            };
            if (combinations.ContainsKey(page))
            {
                return combinations[page];
            }
            return new TagFamily[0];
        }
    }
}
