namespace StatStore.Loader.Core.Models
{
    public class RequestQueueLoadRecord
    {
        public RequestQueueLoadRecord()
        {
            LoadedAt = DateTime.MinValue;
        }

        public RequestQueueLoadRecord(DateTime loadedAt)
        {
            LoadedAt = loadedAt;
        }

        public DateTime LoadedAt { get; set; }
    }
}
