using Iroh.Data;

namespace Iroh.Services
{
    public interface ITagService
    {
        public Subject GetEnumByString(string name);
        public TagFamily[] GetTagFamilies(Subject page);
    }
}
