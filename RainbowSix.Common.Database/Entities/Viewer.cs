namespace RainbowSix.Common.Database.Entities
{
    public class Viewer
    {
        public Guid Id { get; set; }
        public Guid ViewerMetaId { get; set; }
        public ViewerMeta Meta { get; set; }
    }
}
