namespace Iroh.Services
{
    public interface IUpvoteService
    {
        public Task<bool> DoesUpvoteExistAlready(int thingId, string userid);
        public Task<bool> CreateUpvote(int thingId, string userid);
        public Task<bool> RemoveUpvote(int thingId, string userid);
    }
}
