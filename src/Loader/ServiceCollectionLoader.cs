using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core;
using StatStore.Loader.Core.Data;
using StatStore.Loader.Core.Data.Fixtures.Scheduler;
using StatStore.Loader.Core.Data.Fixtures.Scheduler.Interfaces;
using StatStore.Loader.Core.Data.Fixtures.SportsDataIO;
using StatStore.Loader.Core.Data.Fixtures.SportsDataIO.Interfaces;
using StatStore.Loader.Core.Data.Loaders.DataLoaders;
using StatStore.Loader.Core.Data.Loaders.DataLoaders.Interfaces;
using StatStore.Loader.Core.Data.Loaders.ScheduleLoaders;
using StatStore.Loader.Core.Data.Loaders.ScheduleLoaders.Interfaces;
using StatStore.Loader.Core.Interfaces;
using StatStore.Loader.Core.Services;
using StatStore.Loader.Core.Services.Interfaces;
using StatStore.Loader.SportsDataIO;
using StatStore.Loader.SportsDataIO.Endpoints;
using StatStore.Loader.SportsDataIO.Endpoints.Interfaces;
using StatStore.Loader.SportsDataIO.Interfaces;

namespace StatStore.Loader
{
    public static class ServiceCollectionLoader
    {
        public static void AddCoreServices(
            IServiceCollection services)
        {
            services.AddSingleton<program>();
            services.AddTransient<ICustomHttpClient, SportsDataIOHttpClient>();
            services.AddTransient<IQueueRequests, RequestQueue>();
            services.AddSingleton<StateStore>();
            services.AddTransient<ILoadState, StateLoader>();
        }

        public static void AddScheduleDb(
            IServiceCollection services,
            string connStr)
        {
            services.AddDbContextPool<AppScheduleContext>(options =>
                options.UseMySql(connStr,
                    new MySqlServerVersion(new Version(10, 5, 13))));
        }

        public static void AddSportsDataDb(
            IServiceCollection services,
            string connStr)
        {
            services.AddDbContextPool<AppDataContext>(options =>
                options.UseMySql(connStr,
                    new MySqlServerVersion(new Version(10, 5, 13))));
        }

        public static void AddEndPoints(IServiceCollection services)
        {
            services.AddTransient<IFetchTimeFrame, TimeFrameEndpoint>();
        }

        public static void AddDataLoaders(IServiceCollection services)
        {
            services.AddTransient<ILoadTimeFrame, TimeFrameLoader>();
            services.AddTransient<ILoadRecords, RecordLoader>();
        }

        public static void AddDbFixtures(IServiceCollection services)
        {
            services.AddTransient<ITimeFrameFixture, TimeFrameFixture>();
            services.AddTransient<ILoadRecordFixture, LoadRecordFixture>();
            services.AddTransient<IRequestQueueFixture, RequestQueueFixture>();
        }
    }
}
