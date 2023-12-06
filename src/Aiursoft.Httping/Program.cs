// Program.cs
using Aiursoft.CommandFramework;
using Aiursoft.CommandFramework.Extensions;
using Aiursoft.Httping;

var command = new PingHandler().BuildAsCommand();

return await new AiursoftCommandApp(command)
    .RunAsync(args.WithDefaultTo(OptionsProvider.ServerOption));
