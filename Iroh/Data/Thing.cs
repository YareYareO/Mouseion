using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iroh.Data
{
    public class Thing
    {
        public Thing() { Name = String.Empty; Description = String.Empty; Creator = String.Empty; }
        public Thing(string name, string description, UsedInApp app)
        {
            Name = name;
            Description = description;
            App = app;
            CreatedAt = DateTime.Now;
            Upvotes = 0;
            Creator = String.Empty;
        }
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(512)")]
        public string Description { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }
        public UsedInApp App { get; set; }
        public int Upvotes { get; set; } = 0;
        [Column(TypeName = "varchar(450)")]
        public string Creator { get; set; }

    }
}
