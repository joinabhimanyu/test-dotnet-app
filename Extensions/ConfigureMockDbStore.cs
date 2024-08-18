using System;
using test_dotnet_app.DbStore;

namespace test_dotnet_app.Extensions;

public static class ConfigureMockDbStoreWrapper
{
    public static void ConfigureMockDbStore(this IServiceCollection services){
        services.AddSingleton<IMockDbStore>(new MockDbStore());
    }
}
