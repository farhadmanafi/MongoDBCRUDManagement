using MongoDBPersistent.Configuration;

namespace MongoDBCRUD.Configuration
{
    public static class AppConfigurator
    {
        public static void ConfigMongoDb(IServiceCollection serviceCollection, HostBuilderContext context)
        {
            var config = context.Configuration.GetSection("MongoDbConfiguration").Get<MongoDbConfiguration>();

            serviceCollection.AddSingleton(config);
        }
    }
}
