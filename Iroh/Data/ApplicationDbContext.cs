using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Iroh.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Thing> Things {  get; set; } = default!;
        public DbSet<Tag> Tags { get; set; } = default!;
        public DbSet<Upvote> Upvotes { get; set; } = default!;
        public DbSet<Description> Descriptions { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Upvote>().HasKey(upv => new { upv.UserId, upv.ThingId });
            modelBuilder.Entity<Description>().HasKey(desc => new { desc.ThingId, desc.TagId});

            modelBuilder.Entity<Tag>().HasData(
                
                new Tag { Id = 1, Name = "Painting", Family = TagFamily.Art},
                new Tag { Id = 2, Name = "Sculpture", Family = TagFamily.Art},
                new Tag { Id = 3, Name = "Theatre Act", Family = TagFamily.Art},
                
                new Tag { Id = 4, Name = "Ancient Civilization", Family = TagFamily.Place },
                new Tag { Id = 5, Name = "Archaeological Site", Family = TagFamily.Place},
                new Tag { Id = 6, Name = "Battlefield", Family = TagFamily.Place},
                new Tag { Id = 7, Name = "Building", Family = TagFamily.Place},
                new Tag { Id = 8, Name = "Landmark", Family = TagFamily.Place},
                new Tag { Id = 9, Name = "Memorial", Family = TagFamily.Place},
                new Tag { Id = 10, Name = "Monument", Family = TagFamily.Place},
                new Tag { Id = 11, Name = "Palace or Castle", Family = TagFamily.Place},
                new Tag { Id = 12, Name = "Religious Site", Family = TagFamily.Place},
                new Tag { Id = 13, Name = "Ruins", Family = TagFamily.Place},
                
                new Tag { Id = 14, Name = "Activist", Family = TagFamily.Person },
                new Tag { Id = 15, Name = "Actor", Family = TagFamily.Person},
                new Tag { Id = 16, Name = "Artist", Family = TagFamily.Person},
                new Tag { Id = 17, Name = "Athlete", Family = TagFamily.Person},
                new Tag { Id = 18, Name = "Author", Family = TagFamily.Person},
                new Tag { Id = 19, Name = "Businessman", Family = TagFamily.Person},
                new Tag { Id = 20, Name = "Musician", Family = TagFamily.Person},
                new Tag { Id = 21, Name = "Philosopher", Family = TagFamily.Person},
                new Tag { Id = 22, Name = "Politician", Family = TagFamily.Person},
                new Tag { Id = 23, Name = "Scientist", Family = TagFamily.Person},
                new Tag { Id = 24, Name = "Writer", Family = TagFamily.Person},
                new Tag { Id = 25, Name = "Ghost", Family = TagFamily.Person},
                
                new Tag { Id = 26, Name = "Amphibian", Family = TagFamily.Animal },
                new Tag { Id = 27, Name = "Bird", Family = TagFamily.Animal},
                new Tag { Id = 28, Name = "Insect", Family = TagFamily.Animal},
                new Tag { Id = 29, Name = "Fish", Family = TagFamily.Animal},
                new Tag { Id = 30, Name = "Mammal", Family = TagFamily.Animal},
                new Tag { Id = 31, Name = "Reptile", Family = TagFamily.Animal},

                /* new Tag { Id = 1, Name = "Tree", Family = TagFamily.Plant},
                new Tag { Id = 1, Name = "Flower", Family = TagFamily.Plant},
                new Tag { Id = 1, Name = "Fruit", Family = TagFamily.Plant},
                new Tag { Id = 1, Name = "Mosses or Liverworts", Family = TagFamily.Plant},
                new Tag { Id = 1, Name = "Vegetable", Family = TagFamily.Plant}, */


                new Tag { Id = 32, Name = "Battles", Family = TagFamily.Event},
                new Tag { Id = 33, Name = "Discovery", Family = TagFamily.Event},
                new Tag { Id = 34, Name = "Holiday", Family = TagFamily.Event},
                new Tag { Id = 35, Name = "Invention", Family = TagFamily.Event},
                new Tag { Id = 36, Name = "Natural Disaster", Family = TagFamily.Event},
                new Tag { Id = 37, Name = "Political Action", Family = TagFamily.Event},
                new Tag { Id = 38, Name = "Revolution or Civil War", Family = TagFamily.Event},
                new Tag { Id = 39, Name = "War", Family = TagFamily.Event},
                new Tag { Id = 40, Name = "Other Event", Family = TagFamily.Event},

                new Tag { Id = 41, Name = "Anecdote", Family = TagFamily.Writing},
                new Tag { Id = 42, Name = "Article", Family = TagFamily.Writing},
                new Tag { Id = 43, Name = "Book", Family = TagFamily.Writing},
                new Tag { Id = 44, Name = "Essay", Family = TagFamily.Writing},
                new Tag { Id = 45, Name = "Legend", Family = TagFamily.Writing},
                new Tag { Id = 46, Name = "Paper", Family = TagFamily.Writing},
                new Tag { Id = 47, Name = "Poem", Family = TagFamily.Writing},
                new Tag { Id = 48, Name = "Quote", Family = TagFamily.Writing},
                new Tag { Id = 49, Name = "Series of Writings", Family = TagFamily.Writing},
                new Tag { Id = 50, Name = "Tale", Family = TagFamily.Writing},
                new Tag { Id = 51, Name = "Fiction", Family = TagFamily.Writing},
                new Tag { Id = 52, Name = "Non-Fiction", Family = TagFamily.Writing},

                new Tag { Id = 53, Name = "Album", Family = TagFamily.Music },
                new Tag { Id = 54, Name = "Mixtape", Family = TagFamily.Music},
                new Tag { Id = 55, Name = "Single", Family = TagFamily.Music},

                new Tag { Id = 56, Name = "Anime", Family = TagFamily.MotionPicture},
                new Tag { Id = 57, Name = "Movie", Family = TagFamily.MotionPicture},
                new Tag { Id = 58, Name = "Series", Family = TagFamily.MotionPicture},
                new Tag { Id = 59, Name = "Shortmovie", Family = TagFamily.MotionPicture},
                new Tag { Id = 60, Name = "Other Video", Family = TagFamily.MotionPicture},

                new Tag { Id = 61, Name = "Board", Family = TagFamily.Game},
                new Tag { Id = 62, Name = "Card", Family = TagFamily.Game},
                new Tag { Id = 63, Name = "Party", Family = TagFamily.Game},
                new Tag { Id = 64, Name = "Puzzle", Family = TagFamily.Game},

                new Tag { Id = 65, Name = "Home Utility", Family = TagFamily.Invention},
                new Tag { Id = 66, Name = "Survival", Family = TagFamily.Invention},
                new Tag { Id = 67, Name = "Labor Utility", Family = TagFamily.Invention},
                new Tag { Id = 68, Name = "Electronic", Family = TagFamily.Invention},
                new Tag { Id = 69, Name = "Quality of Life", Family = TagFamily.Invention},
                new Tag { Id = 70, Name = "Universal Utility", Family = TagFamily.Invention},
                new Tag { Id = 71, Name = "Chemical", Family = TagFamily.Invention},

                new Tag { Id = 72, Name = "Europe", Family = TagFamily.Region},
                new Tag { Id = 73, Name = "Africa", Family = TagFamily.Region},
                new Tag { Id = 74, Name = "Asia", Family = TagFamily.Region},
                new Tag { Id = 75, Name = "Middle East", Family = TagFamily.Region},
                new Tag { Id = 76, Name = "North America", Family = TagFamily.Region},
                new Tag { Id = 77, Name = "Oceania", Family = TagFamily.Region},
                new Tag { Id = 78, Name = "Ocean", Family = TagFamily.Region},
                new Tag { Id = 79, Name = "South America", Family = TagFamily.Region},
                
                new Tag { Id = 80, Name = "21th Century", Family = TagFamily.Time },
                new Tag { Id = 81, Name = "20th Century", Family = TagFamily.Time},
                new Tag { Id = 82, Name = "19th Century", Family = TagFamily.Time},
                new Tag { Id = 83, Name = "18th Century", Family = TagFamily.Time},
                new Tag { Id = 84, Name = "17th Century", Family = TagFamily.Time},
                new Tag { Id = 85, Name = "16th Century", Family = TagFamily.Time},
                new Tag { Id = 86, Name = "5th to 15th Century", Family = TagFamily.Time},
                new Tag { Id = 87, Name = "Ancient to 4th Century", Family = TagFamily.Time},
                new Tag { Id = 88, Name = "Pre Historic", Family = TagFamily.Time},

                new Tag { Id = 89, Name = "Archaeology", Family = TagFamily.Science},
                new Tag { Id = 90, Name = "Astrology :)", Family = TagFamily.Science},
                new Tag { Id = 91, Name = "Astronomy", Family = TagFamily.Science},
                new Tag { Id = 92, Name = "Biology", Family = TagFamily.Science},
                new Tag { Id = 93, Name = "Chemistry", Family = TagFamily.Science},
                new Tag { Id = 94, Name = "Economy", Family = TagFamily.Science},
                new Tag { Id = 95, Name = "Neurological", Family = TagFamily.Science},
                new Tag { Id = 96, Name = "Psychology", Family = TagFamily.Science},
                new Tag { Id = 97, Name = "Physics", Family = TagFamily.Science},
                new Tag { Id = 98, Name = "Sociology", Family = TagFamily.Science},

                new Tag { Id = 99, Name = "Basketball", Family = TagFamily.Sport},
                new Tag { Id = 100, Name = "Car Racing", Family = TagFamily.Sport},
                new Tag { Id = 101, Name = "Esports", Family = TagFamily.Sport},
                new Tag { Id = 102, Name = "Football", Family = TagFamily.Sport },
                new Tag { Id = 103, Name = "Martial Arts", Family = TagFamily.Sport},
                new Tag { Id = 104, Name = "Rugby or American Football", Family = TagFamily.Sport },
                new Tag { Id = 105, Name = "Running", Family = TagFamily.Sport},
                new Tag { Id = 106, Name = "Swimming", Family = TagFamily.Sport },
                new Tag { Id = 107, Name = "Tennis", Family = TagFamily.Sport },
                new Tag { Id = 108, Name = "Volleyball", Family = TagFamily.Sport},
                new Tag { Id = 109, Name = "Weightlifting", Family = TagFamily.Sport},
                new Tag { Id = 110, Name = "Other Sport", Family = TagFamily.Sport },

                new Tag { Id = 111, Name = "About Children", Family = TagFamily.Topic },
                new Tag { Id = 112, Name = "Advice", Family = TagFamily.Topic },
                new Tag { Id = 113, Name = "Art or Photography", Family = TagFamily.Topic },
                new Tag { Id = 114, Name = "Biography", Family = TagFamily.Topic },
                new Tag { Id = 115, Name = "Commentary", Family = TagFamily.Topic },
                new Tag { Id = 116, Name = "Documentary", Family = TagFamily.Topic },
                new Tag { Id = 117, Name = "Finance", Family = TagFamily.Topic },
                new Tag { Id = 118, Name = "Guide", Family = TagFamily.Topic },
                new Tag { Id = 119, Name = "Memoir", Family = TagFamily.Topic },
                new Tag { Id = 120, Name = "Parenting", Family = TagFamily.Topic },
                new Tag { Id = 121, Name = "Past Civilization", Family = TagFamily.Topic },
                new Tag { Id = 122, Name = "Philosophy", Family = TagFamily.Topic },
                new Tag { Id = 123, Name = "Political", Family = TagFamily.Topic },
                new Tag { Id = 124, Name = "Self-Help", Family = TagFamily.Topic },
                new Tag { Id = 125, Name = "Personal Relationship", Family = TagFamily.Topic },
                new Tag { Id = 126, Name = "Religion", Family = TagFamily.Topic },
                new Tag { Id = 127, Name = "Technology", Family = TagFamily.Topic },
                new Tag { Id = 128, Name = "True Crime", Family = TagFamily.Topic },

                new Tag { Id = 129, Name = "Action", Family = TagFamily.FictionGenre },
                new Tag { Id = 130, Name = "Adventure", Family = TagFamily.FictionGenre},
                new Tag { Id = 131, Name = "Crime", Family = TagFamily.FictionGenre},
                new Tag { Id = 132, Name = "Drama", Family = TagFamily.FictionGenre},
                new Tag { Id = 133, Name = "Dystopian", Family = TagFamily.FictionGenre},
                new Tag { Id = 134, Name = "Fantasy", Family = TagFamily.FictionGenre},
                new Tag { Id = 135, Name = "Historical", Family = TagFamily.FictionGenre},
                new Tag { Id = 136, Name = "Horror", Family = TagFamily.FictionGenre},
                new Tag { Id = 137, Name = "Mystery", Family = TagFamily.FictionGenre},
                new Tag { Id = 138, Name = "Noir", Family = TagFamily.FictionGenre},
                new Tag { Id = 139, Name = "Romance", Family = TagFamily.FictionGenre},
                new Tag { Id = 140, Name = "Satire", Family = TagFamily.FictionGenre},
                new Tag { Id = 141, Name = "Science Fiction", Family = TagFamily.FictionGenre},
                new Tag { Id = 142, Name = "Seinen", Family = TagFamily.FictionGenre},
                new Tag { Id = 143, Name = "Shoji", Family = TagFamily.FictionGenre},
                new Tag { Id = 144, Name = "Shonen", Family = TagFamily.FictionGenre},
                new Tag { Id = 145, Name = "Swashbuckle", Family = TagFamily.FictionGenre},
                new Tag { Id = 146, Name = "Thriller", Family = TagFamily.FictionGenre},

                new Tag { Id = 147, Name = "Fun or Comedy", Family = TagFamily.Category},
                new Tag { Id = 148, Name = "Indie", Family = TagFamily.Category},
                new Tag { Id = 149, Name = "Safe For Children", Family = TagFamily.Category},
                new Tag { Id = 150, Name = "Was Banned Somewhere", Family = TagFamily.Category},

                new Tag { Id = 151, Name = "Classical", Family = TagFamily.MusicGenre },
                new Tag { Id = 152, Name = "Electronic", Family = TagFamily.MusicGenre},
                new Tag { Id = 153, Name = "Hip-Hop", Family = TagFamily.MusicGenre},
                new Tag { Id = 154, Name = "Jazz", Family = TagFamily.MusicGenre},
                new Tag { Id = 155, Name = "Metal", Family = TagFamily.MusicGenre},
                new Tag { Id = 156, Name = "Pop", Family = TagFamily.MusicGenre},
                new Tag { Id = 157, Name = "Reggae", Family = TagFamily.MusicGenre},
                new Tag { Id = 158, Name = "R&B", Family = TagFamily.MusicGenre},
                new Tag { Id = 159, Name = "Rock", Family = TagFamily.MusicGenre},
                new Tag { Id = 160, Name = "Soundtrack", Family = TagFamily.MusicGenre},

                new Tag { Id = 161, Name = "2D", Family = TagFamily.VideoGameGenre},
                new Tag { Id = 162, Name = "3D", Family = TagFamily.VideoGameGenre},
                new Tag { Id = 163, Name = "Action", Family = TagFamily.VideoGameGenre},
                new Tag { Id = 164, Name = "Puzzle", Family = TagFamily.VideoGameGenre},
                new Tag { Id = 165, Name = "Multiplayer", Family = TagFamily.VideoGameGenre},
                new Tag { Id = 166, Name = "RPG", Family = TagFamily.VideoGameGenre},
                new Tag { Id = 167, Name = "Simulation", Family = TagFamily.VideoGameGenre},
                new Tag { Id = 168, Name = "Shooter", Family = TagFamily.VideoGameGenre},
                new Tag { Id = 169, Name = "Sandbox", Family = TagFamily.VideoGameGenre},

                new Tag { Id = 170, Name = "Fictional", Family = TagFamily.Reality},
                new Tag { Id = 171, Name = "Mythological", Family = TagFamily.Reality},
                new Tag { Id = 172, Name = "Religious", Family = TagFamily.Reality}
                // TODO Timer bei create page
                // TODO Regeln und Guidelines aufschreiben
                // TODO Check ob titel schon existiert
                // TODO Plant
        );
        }
    }
}