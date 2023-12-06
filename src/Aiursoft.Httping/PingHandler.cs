using System.CommandLine;
using System.CommandLine.Invocation;
using Aiursoft.CommandFramework.Framework;
using Aiursoft.CommandFramework.Models;
using Aiursoft.CommandFramework.Services;
using Aiursoft.Httping.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aiursoft.Httping;

public class PingHandler : CommandHandler
{
    public override string Name => "httping";

    public override string Description => "Ping a server with HTTP protocol."; 

    public override Option[] GetCommandOptions() => new Option[]
    {
        OptionsProvider.ServerOption,
        OptionsProvider.CountOption,
        OptionsProvider.TimeoutOption,
        OptionsProvider.IntervalOption,
        OptionsProvider.InsecureOption,
        OptionsProvider.QuietOption,
        CommonOptionsProvider.VerboseOption,
    };
    
    protected override async Task Execute(InvocationContext context)
    {
        var server = context.ParseResult.GetValueForOption(OptionsProvider.ServerOption)!;
        var count = context.ParseResult.GetValueForOption(OptionsProvider.CountOption);
        var timeout = context.ParseResult.GetValueForOption(OptionsProvider.TimeoutOption);
        var interval = context.ParseResult.GetValueForOption(OptionsProvider.IntervalOption);
        var insecure = context.ParseResult.GetValueForOption(OptionsProvider.InsecureOption);
        var quiet = context.ParseResult.GetValueForOption(OptionsProvider.QuietOption);
        var verbose = context.ParseResult.GetValueForOption(CommonOptionsProvider.VerboseOption);

        var host = ServiceBuilder
            .CreateCommandHostBuilder<Startup>(verbose)
            .Build();

        await host.StartAsync();

        var pingWorker = host.Services.GetRequiredService<PingWorker>();
        await pingWorker.HttpPing(
            url: server, 
            count: count, 
            timeout: TimeSpan.FromMilliseconds(timeout),
            interval: TimeSpan.FromMilliseconds(interval), 
            insecure: insecure,
            quiet: quiet);
    }
}