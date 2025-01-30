using System.CommandLine;
using System.CommandLine.Invocation;
using Aiursoft.CommandFramework.Framework;
using Aiursoft.CommandFramework.Models;
using Aiursoft.CommandFramework.Services;
using Aiursoft.Httping.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aiursoft.Httping;

public class PingHandler : ExecutableCommandHandlerBuilder
{
    protected override string Name => "httping";

    protected override string Description => "Ping a server with HTTP protocol.";

    protected override Option[] GetCommandOptions() =>
    [
        OptionsProvider.ServerOption,
        OptionsProvider.CountOption,
        OptionsProvider.TimeoutOption,
        OptionsProvider.IntervalOption,
        OptionsProvider.InsecureOption,
        OptionsProvider.QuietOption,
        OptionsProvider.FollowRedirectOption,
        CommonOptionsProvider.VerboseOption
    ];
    
    protected override async Task Execute(InvocationContext context)
    {
        var server = context.ParseResult.GetValueForOption(OptionsProvider.ServerOption)!;
        var count = context.ParseResult.GetValueForOption(OptionsProvider.CountOption);
        var timeout = context.ParseResult.GetValueForOption(OptionsProvider.TimeoutOption);
        var interval = context.ParseResult.GetValueForOption(OptionsProvider.IntervalOption);
        var insecure = context.ParseResult.GetValueForOption(OptionsProvider.InsecureOption);
        var quiet = context.ParseResult.GetValueForOption(OptionsProvider.QuietOption);
        var followRedirect = context.ParseResult.GetValueForOption(OptionsProvider.FollowRedirectOption);
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
            quiet: quiet,
            followRedirect: followRedirect);
    }
}