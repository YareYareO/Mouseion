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
        public Tag(string name, UsedInApp app)
        {
            Name = name;
        }
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public TagFamily Family { get; set; }
    }
}
