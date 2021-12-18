using StatStore.Loader.Core.Interfaces;

namespace StatStore.Loader.Core.Services
{
    public class StateLoader
    {
        private readonly ILogger<StateLoader> logger;
        private readonly StateStore state;

        public StateLoader(ILogger<StateLoader> logger)
        {
            this.logger = logger;
            state = new();
        }

        public StateStore State { get => state; }

        public async Task Initialize()
        {

        }
    }
}
