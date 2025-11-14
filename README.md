# Httping

[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://gitlab.aiursoft.com/aiursoft/httping/-/blob/master/LICENSE)
[![Pipeline stat](https://gitlab.aiursoft.com/aiursoft/httping/badges/master/pipeline.svg)](https://gitlab.aiursoft.com/aiursoft/httping/-/pipelines)
[![Test Coverage](https://gitlab.aiursoft.com/aiursoft/httping/badges/master/coverage.svg)](https://gitlab.aiursoft.com/aiursoft/httping/-/pipelines)
[![NuGet version (Aiursoft.Httping)](https://img.shields.io/nuget/v/Aiursoft.Httping.svg)](https://www.nuget.org/packages/Aiursoft.Httping/)
[![ManHours](https://manhours.aiursoft.com/r/gitlab.aiursoft.com/aiursoft/httping.svg)](https://gitlab.aiursoft.com/aiursoft/httping/-/commits/master?ref_type=heads)

Httping is a simple HTTP ping tool. It can ping a website and get the response time.

## Installation

Requirements:

1. [.NET 10 SDK](http://dot.net/)

Run the following command to install this tool:

```bash
dotnet tool install --global Aiursoft.Httping
```

## Usage

After getting the binary, run it directly in the terminal.

```bash
$ httping www.bing.com
```

That's it! It will ping the website and get the response time.

```bash
1: 1.1, www.bing.com:443, code=OK, size=40744 bytes, time=837.8612 ms
2: 1.1, www.bing.com:443, code=OK, size=40675 bytes, time=418.0189 ms
3: 1.1, www.bing.com:443, code=OK, size=40675 bytes, time=413.7146 ms
4: 1.1, www.bing.com:443, code=OK, size=40675 bytes, time=407.5908 ms

Ping statistics for www.bing.com
    Packets: Sent = 4, Received = 4, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = 407.5908ms, Maximum = 837.8612ms, Average = 519.2964ms
```

And it support options:

```bash
Options:
  --server <server> (REQUIRED)  The server address to ping. Can be a domain name or an IP address.
  -n, --count <count>           The number of echo requests to send. The default is 4. [default: 4]
  -w, --timeout <timeout>       Timeout in milliseconds to wait for each reply. The default is 5000. [default: 5000]
  -i, --interval <interval>     Time in milliseconds to wait between pings. The default is 1000. [default: 1000]
  -k, --insecure                Allow insecure server connections when using SSL. [default: False]
  -q, --quiet                   Quiet output. Nothing is displayed except the summary lines at startup time and when finished. [default: False]
  -f, --follow-redirect         Follow HTTP redirects. [default: False]
  -v, --verbose                 Show detailed log
  --version                     Show version information
  -?, -h, --help                Show help and usage information
```

## Run locally

Requirements about how to run

1. [.NET 10 SDK](http://dot.net/)
2. Execute `dotnet run` to run the app

## Run in Microsoft Visual Studio

1. Open the `.sln` file in the project path.
2. Press `F5`.

## How to contribute

There are many ways to contribute to the project: logging bugs, submitting pull requests, reporting issues, and creating suggestions.

Even if you with push rights on the repository, you should create a personal fork and create feature branches there when you need them. This keeps the main repository clean and your workflow cruft out of sight.

We're also interested in your feedback on the future of this project. You can submit a suggestion or feature request through the issue tracker. To make this process more effective, we're asking that these include more information to help define them more clearly.
