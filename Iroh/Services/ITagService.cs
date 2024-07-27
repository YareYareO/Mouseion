using Iroh.Data;

namespace Iroh.Services
{
    public interface ITagService
    {
        public UsedInApp GetEnumByString(string name);
        public TagFamily[] GetTagFamilies(UsedInApp page);
    }
}
