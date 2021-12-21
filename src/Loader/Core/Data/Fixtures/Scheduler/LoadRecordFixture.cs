using StatStore.Loader.Core.Data.Fixtures.Scheduler.Interfaces;
using StatStore.Loader.Core.Data.Interfaces;
using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Data.Fixtures.Scheduler
{
    public class LoadRecordFixture : ILoadRecordFixture
    {
        private IGenericDataRepo<LoadRecord> repo;

        public LoadRecordFixture(
            IGenericDataRepo<LoadRecord> repo)
        {
            this.repo = repo;
        }
        
        public async Task<LoadRecord> Get()
        {
            return await Task.FromResult(
                repo.GetById(1))?? new(){Id = -1};
        }

        public async Task Update(LoadRecord record)
        {
            record.LastUpdate = DateTime.Now;
            repo.Update(record);
            await Task.CompletedTask;
        }
    }
}
