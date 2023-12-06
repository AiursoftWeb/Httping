using Aiursoft.CommandFramework.Abstracts;
using Aiursoft.Httping.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aiursoft.Httping;

public class Startup : IStartUp
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<PingWorker>();
    }
}