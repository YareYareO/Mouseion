using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iroh.Data
{
    public class Tag
    {
        public Tag()
        {
            Name = String.Empty;
        }
        public Tag(string name, int? parent, UsedInApp app, TagType type)
        {
            Name = name;
            Parent = parent;
            App = app;
            TagType = type;
        }
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public int? Parent { get; set; }

        public UsedInApp App { get; set; }
        public TagType TagType { get; set; }
    }
}
