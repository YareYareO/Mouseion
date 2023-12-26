namespace Iroh.Data
{
    public class Description
    {
        public Description() { }
        public Description(int tag, int thing) 
        {
            TagId = tag;
            ThingId = thing;
        }
        public Description(Tag tag, Thing thing)
        {
            TagId = tag.Id;
            ThingId = thing.Id;
        }

        public int TagId { get; set; }
        public int ThingId { get; set; }
    }
}
