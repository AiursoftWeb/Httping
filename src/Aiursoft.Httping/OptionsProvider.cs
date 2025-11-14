using System.CommandLine;

namespace Aiursoft.Httping;

public static class OptionsProvider
{
    public static readonly Option<string> ServerOption = new(
        name: "--server")
    {
        Description = "The server address to ping. Can be a domain name or an IP address.",
        Required = true,
    };

    public static readonly Option<int> CountOption = new(
        name: "--count",
        aliases: ["-n"])
    {
        DefaultValueFactory = _ => 4,
        Description = "The number of echo requests to send. The default is 4.",
        Required = false,
    };

    public static readonly Option<int> TimeoutOption = new(
        name: "--timeout",
        aliases: ["-w"])
    {
        DefaultValueFactory = _ => 5000,
        Description = "Timeout in milliseconds to wait for each reply. The default is 5000.",
        Required = false,
    };

    public static readonly Option<int> IntervalOption = new(
        name: "--interval",
        aliases: ["-i"])
    {
        DefaultValueFactory = _ => 1000,
        Description = "Time in milliseconds to wait between pings. The default is 1000.",
        Required = false,
    };

    public static readonly Option<bool> InsecureOption = new(
        name: "--insecure",
        aliases: ["-k"])
    {
        DefaultValueFactory = _ => false,
        Description = "Allow insecure server connections when using SSL.",
        Required = false,
    };

    public static readonly Option<bool> QuietOption = new(
        name: "--quiet",
        aliases: ["-q"])
    {
        DefaultValueFactory = _ => false,
        Description = "Quiet output. Nothing is displayed except the summary lines at startup time and when finished.",
        Required = false,
    };

    public static readonly Option<bool> FollowRedirectOption = new(
        name: "--follow-redirect",
        aliases: ["-f"])
    {
        DefaultValueFactory = _ => false,
        Description = "Follow HTTP redirects.",
        Required = false,
    };

    public static readonly Option<bool> NoProxyOption = new(
        name: "--no-proxy")
    {
        DefaultValueFactory = _ => false,
        Description = "Do not use a proxy server.",
        Required = false,
    };
}
