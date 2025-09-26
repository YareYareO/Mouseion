using Iroh.Data;

namespace Iroh.Services
{
    public interface ITagService
    {
        public static List<Tag> AllTags = [];
        public Subject GetEnumByString(string name);
        public TagFamily[] GetSubjectFamilies(Subject page);
        public Task<List<Tag>> GetTagsByFamilies(TagFamily[] app);

    }
}
