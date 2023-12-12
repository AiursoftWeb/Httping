using Aiursoft.CommandFramework;
using Aiursoft.Httping;

return await new SingleCommandApp<PingHandler>()
    .WithDefaultOption(OptionsProvider.ServerOption)
    .RunAsync(args);
