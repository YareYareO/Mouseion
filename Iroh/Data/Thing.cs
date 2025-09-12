using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iroh.Data
{
    [Index(nameof(Name), IsUnique = true)]
    public class Thing
    {
        public Thing() { Name = String.Empty; Description = String.Empty; Creator = String.Empty; }
        public Thing(Subject s)
        {
            App = s;
            CreatedAt = DateTime.Now;
            Upvotes = 0;

            Name = String.Empty;
            Description = String.Empty;
            Creator = String.Empty;
        }
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be 2-100 characters.")]
        [RegularExpression(@"^[^\\\$\;\@\#\^\*$$$$$$\{\}<>~`|/\\]+$",
        ErrorMessage = "Name contains invalid characters.")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(512)")]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(512, MinimumLength = 24, ErrorMessage = "Description must be between 24-512 characters.")]
        [RegularExpression(@"^[^\\\$\;\@\#\^\*$$$$$$\{\}<>~`|/\\]+$", 
        ErrorMessage = "Description contains invalid characters.")]
        public string Description { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }
        public Subject App { get; set; }
        public int Upvotes { get; set; } = 0;
        [Column(TypeName = "varchar(450)")]
        [Required(ErrorMessage = "Nickname is required. This will not be displayed publicly.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Nickname must be 4-32 characters.")]
        [RegularExpression(@"^[^\\\$\,\;\:\@\!\#\%\^\&\*$$$$$$\{\}<>~`|/\\]+$",
        ErrorMessage = "Nickname contains invalid characters.")]
        public string Creator { get; set; }

    }
}
