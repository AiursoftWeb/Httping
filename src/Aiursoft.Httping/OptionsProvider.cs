using System.CommandLine;

namespace Aiursoft.Httping;

public static class OptionsProvider
{
    public static readonly Option<string> ServerOption = new(
        aliases: new[] { "--server" },
        description: "The server address to ping. Can be a domain name or an IP address.")
    {
        IsRequired = true,
    };
    
    public static readonly Option<int> CountOption = new(
        aliases: new[] { "--count", "-n" },
        getDefaultValue: () => 4,
        description: "The number of echo requests to send. The default is 4.")
    {
        IsRequired = false,
    };
    
    public static readonly Option<int> TimeoutOption = new(
        aliases: new[] { "--timeout", "-w" },
        getDefaultValue: () => 5000,
        description: "Timeout in milliseconds to wait for each reply. The default is 5000.")
    {
        IsRequired = false,
    };
    
    public static readonly Option<int> IntervalOption = new(
        aliases: new[] { "--interval", "-i" },
        getDefaultValue: () => 1000,
        description: "Time in milliseconds to wait between pings. The default is 1000.")
    {
        IsRequired = false,
    };
    
    public static readonly Option<bool> InsecureOption = new(
        aliases: new[] { "--insecure", "-k" },
        getDefaultValue: () => false,
        description: "Allow insecure server connections when using SSL.")
    {
        IsRequired = false,
    };
    
    public static readonly Option<bool> QuietOption = new(
        aliases: new[] { "--quiet", "-q" },
        getDefaultValue: () => false,
        description: "Quiet output. Nothing is displayed except the summary lines at startup time and when finished.")
    {
        IsRequired = false,
    };
}