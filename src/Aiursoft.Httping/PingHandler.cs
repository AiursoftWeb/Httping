using System.CommandLine;
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
        OptionsProvider.NoProxyOption,
        CommonOptionsProvider.VerboseOption
    ];

    protected override async Task Execute(ParseResult context)
    {
        var server = context.GetValue(OptionsProvider.ServerOption)!;
        var count = context.GetValue(OptionsProvider.CountOption);
        var timeout = context.GetValue(OptionsProvider.TimeoutOption);
        var interval = context.GetValue(OptionsProvider.IntervalOption);
        var insecure = context.GetValue(OptionsProvider.InsecureOption);
        var quiet = context.GetValue(OptionsProvider.QuietOption);
        var followRedirect = context.GetValue(OptionsProvider.FollowRedirectOption);
        var noProxy = context.GetValue(OptionsProvider.NoProxyOption);
        var verbose = context.GetValue(CommonOptionsProvider.VerboseOption);

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
            followRedirect: followRedirect,
            noProxy: noProxy);
    }
}
