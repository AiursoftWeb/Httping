using Aiursoft.CommandFramework;
using Aiursoft.Httping;

return await new SingleCommandApp(new PingHandler())
    .WithDefaultOption(OptionsProvider.ServerOption)
    .RunAsync(args);
