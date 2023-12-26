using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iroh.Data
{
    public class Upvote
    {
        public Upvote()
        {
            UserId = String.Empty;
        }
        public Upvote(int tid, string uid)
        {
            ThingId = tid;
            UserId = uid;
        }
        public Upvote(Thing thing, ApplicationUser user)
        {
            ThingId = thing.Id;
            UserId = user.Id;
        }
        public int ThingId { get; set; }
        public string UserId { get; set; }
    }
}
