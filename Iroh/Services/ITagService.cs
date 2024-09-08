using Iroh.Data;

namespace Iroh.Services
{
    public interface ITagService
    {
        public UsedInApp GetEnumByString(string name);
        public TagFamily[] GetTagFamilies(UsedInApp page);
        public List<Tag> GetTagsByThing(int thingId);
        //public List<int> GetTagNamesByThing(int thingId);
    }
}
