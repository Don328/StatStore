namespace StatStore.Loader.Core.Models
{
    public class LoadRecord
    {
        public LoadRecord()
        {
            Id = 1;
            LastLoad = DateTime.MinValue;
            LastUpdate = DateTime.MinValue;
            TimeFrameLoaded = DateTime.MinValue;
        }


        public int Id { get; set; }
        public DateTime LastLoad { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime TimeFrameLoaded { get; set; }
    }
}
