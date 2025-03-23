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
        public Tag(string name, Subject app)
        {
            Name = name;
        }
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public TagFamily Family { get; set; }
        public bool IsSame(Tag other)
        {
            return this.Name == other.Name && this.Family == other.Family;
        }
    }
}
